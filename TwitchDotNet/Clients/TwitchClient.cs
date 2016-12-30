using System.Collections.Generic;
using TwitchDotNet.Enums;
using TwitchDotNet.Helpers;
using TwitchDotNet.Interfaces;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;

namespace TwitchDotNet.Clients {

    /// <summary>
    ///  TwitchClient
    /// Provides an interface for an  session to retrieve data from Twitch API's (where authentication is not required)
    /// </summary>
    public class TwitchClient : ITwitchClient {

        protected readonly HttpHelper httpHelperClient;

        /// <summary>
        /// Initialise HttpClient for requests
        /// </summary>
        /// <param name="_baseUrl">Base Twitch API url</param>
        /// <param name="_clientId">Client Id header</param>
        public TwitchClient(string _baseUrl, string _clientId) {
            httpHelperClient = new HttpHelper(_baseUrl, _clientId);
        }

        #region General - https://dev.twitch.tv/docs/v5/guides/using-the-twitch-api/

        /// <summary>
        /// Get Twitch Id by Twitch Username.
        /// https://dev.twitch.tv/docs/v5/guides/using-the-twitch-api#translating-from-user-names-to-user-ids
        /// </summary>
        /// <param name="_name">Twitch username</param>
        /// <returns></returns>
        public async Task<dynamic> GetIdByName(string _username) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, "login", _username);
            return await httpHelperClient.ExecuteRequest(request);
        }

        #endregion

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        /// <summary>
        /// Gets a specified channel object.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-by-id
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public async Task<dynamic> GetChannel(string _channelId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/channels/{_channelId}", HttpMethod.Get);
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Gets a list of users who follow a specified channel, sorted by the date when they started following the channel (newest first, unless specified otherwise).
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-followers
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_direction">Sort direction <see cref="Enums.SortDirection"/></param>
        /// <returns></returns>
        public async Task<dynamic> GetChannelFollowers(string _channelId, Pagination _pagination, SortDirection _direction = SortDirection.desc) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/channels/{_channelId}/follows", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            httpHelperClient.AddQueryString(request, "direction", _direction.ToString());
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Gets a list of teams to which a specified channel belongs.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-teams
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public async Task<dynamic> GetChannelTeams(string _channelId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/channels/{_channelId}/teams", HttpMethod.Get);
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Gets a list of VODs (Video on Demand) from a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-videos
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_broadcastType">Broadcast type <see cref="Enums.BroadcastType"/></param>
        /// <param name="_languages">Restrict VODs to specific language(s)</param>
        /// <param name="_sort">Sort by <see cref="Enums.SortBy"/></param>
        /// <returns></returns>
        public async Task<dynamic> GetChannelVideos(string _channelId, Pagination _pagination, BroadcastType _broadcastType = BroadcastType.highlight, List<string> _languages = default(List<string>), SortBy _sort = SortBy.time) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/channels/{_channelId}/videos", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            httpHelperClient.AddQueryString(request, "broadcast_type", _broadcastType.ToString());
            if (_languages != default(List<string>) && _languages.Count > 0) { httpHelperClient.AddQueryString(request, "language", string.Join(",", _languages)); }
            httpHelperClient.AddQueryString(request, "sort", _sort.ToString());
            return await httpHelperClient.ExecuteRequest(request);
        }

        #endregion

        #region Chat - Https://dev.twitch.tv/docs/v5/reference/chat/

        /// <summary>
        /// Gets a list of badges that can be used in chat for a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/chat/#get-chat-badges-by-channel
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public async Task<dynamic> GetChatBadgesByChannel(string _channelId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/chat/{_channelId}/badges", HttpMethod.Get);
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Gets all chat emoticons (not including their images) in a specified set.
        /// Https://dev.twitch.tv/docs/v5/reference/chat/#get-chat-emoticons-by-set
        /// </summary>
        /// <param name="_emoteSets">Emote set</param>
        /// <returns></returns>
        public async Task<dynamic> GetChatBadgesBySet(List<string> _emoteSets = default(List<string>)) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/games/top", HttpMethod.Get);
            if (_emoteSets != default(List<string>) && _emoteSets.Count > 0) { httpHelperClient.AddQueryString(request, "emotesets", string.Join(",", _emoteSets)); }
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Gets all chat emoticons (including their images).
        /// Https://dev.twitch.tv/docs/v5/reference/chat/#get-all-chat-emoticons
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> GetEmoticons() {
            var request = httpHelperClient.CreateHttpRequest($"kraken/chat/emoticons", HttpMethod.Get);
            return await httpHelperClient.ExecuteRequest(request);
        }

        #endregion

        #region Games - Https://dev.twitch.tv/docs/v5/reference/games/

        /// <summary>
        /// Get games by number of current viewers.
        /// Https://dev.twitch.tv/docs/v5/reference/games/#get-top-games
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public async Task<dynamic> GetTopGames(Pagination _pagination) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/games/top", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// **UNOFFOCIAL API** https://discuss.dev.twitch.tv/t/game-following-requests/2186
        /// Get followed games by user.
        /// </summary>
        /// <param name="_username">Username to retrieve followed games for</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public async Task<dynamic> GetFollowedGames(string _username, Pagination _pagination) {
            var request = httpHelperClient.CreateHttpRequest($"api/users/{_username}/follows/games", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            return await httpHelperClient.ExecuteRequest(request);
        }

        #endregion

        #region Ingests - Https://dev.twitch.tv/docs/v5/reference/ingests/

        /// <summary>
        /// Gets a list of ingest servers.
        /// Https://dev.twitch.tv/docs/v5/reference/ingests/#get-ingest-server-list
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> GetIngests() {
            var request = httpHelperClient.CreateHttpRequest($"kraken/ingests", HttpMethod.Get);
            return await httpHelperClient.ExecuteRequest(request);
        }

        #endregion

        #region Search - Https://dev.twitch.tv/docs/v5/reference/search/

        /// <summary>
        /// Search for channels based on the query parameter.
        /// Https://dev.twitch.tv/docs/v5/reference/search/#search-channels
        /// </summary>
        /// <param name="_query">Search query</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public async Task<dynamic> SearchChannels(string _query, Pagination _pagination) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/search/channels", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, "query", _query);
            httpHelperClient.AddQueryString(request, _pagination);
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Search for streams based on the query parameter.
        /// Https://dev.twitch.tv/docs/v5/reference/search/#search-streams
        /// </summary>
        /// <param name="_query">Search query</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_hls">If true, return only HLS streams, false, only non-HLS streams</param>
        /// <returns></returns>
        public async Task<dynamic> SearchStreams(string _query, Pagination _pagination, bool _hls = true) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/search/streams", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, "query", _query);
            httpHelperClient.AddQueryString(request, _pagination);
            httpHelperClient.AddQueryString(request, "hls", _hls.ToString());
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Search for games based on the query parameter.
        /// Https://dev.twitch.tv/docs/v5/reference/search/#search-games
        /// </summary>
        /// <param name="_query">Search query</param>
        /// <param name="_live">If true, return only games that are live on at least one channel, false, return all</param>
        /// <returns></returns>
        public async Task<dynamic> SearchGames(string _query, bool _live = false) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/search/games", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, "query", _query);
            httpHelperClient.AddQueryString(request, "live", _live.ToString());
            return await httpHelperClient.ExecuteRequest(request);
        }

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        /// <summary>
        /// Gets a list of all live streams.
        /// Https://dev.twitch.tv/docs/v5/reference/streams/#get-all-streams
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_game">Restrict streams to specific game</param>
        /// <param name="_channels">Restrict streams to specific channel(s) (by Id)</param>
        /// <param name="_streamType">Stream type <see cref="Enums.StreamType"/></param>
        /// <param name="_language">Restrict VODs to specific language(s)</param>
        /// <returns></returns>
        public async Task<dynamic> GetStreams(Pagination _pagination, string _game = default(string), List<string> _channels = default(List<string>), StreamType _streamType = StreamType.live, List<string> _languages = default(List<string>)) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/streams", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            if (!string.IsNullOrEmpty(_game)) { httpHelperClient.AddQueryString(request, "game", _game); }
            if (_channels != default(List<string>) && _channels.Count > 0) { httpHelperClient.AddQueryString(request, "channel", string.Join(",", _channels)); }
            httpHelperClient.AddQueryString(request, "stream_type", _streamType.ToString());
            if (_languages != default(List<string>) && _languages.Count > 0) { httpHelperClient.AddQueryString(request, "language", string.Join(",", _languages)); }
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Gets stream information (the stream object) for a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/streams/#get-stream-by-channel
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_streamType">Stream type <see cref="Enums.StreamType"/></param>
        /// <returns></returns>
        public async Task<dynamic> GetStream(string _channelId, StreamType _streamType = StreamType.live) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/streams/{_channelId}", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, "stream_type", _streamType.ToString());
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Gets a list of all featured live streams.
        /// Https://dev.twitch.tv/docs/v5/reference/streams/#get-featured-streams
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public async Task<dynamic> GetFeaturedStreams(Pagination _pagination) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/streams/featured", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Gets a summary of all live streams.
        /// Https://dev.twitch.tv/docs/v5/reference/streams/#get-streams-summary
        /// </summary>
        /// <param name="_game">Restrict summary to specific game</param>
        /// <returns></returns>
        public async Task<dynamic> GetStreamsSummary(string _game = default(string)) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/streams/summary", HttpMethod.Get);
            if (!string.IsNullOrEmpty(_game)) { httpHelperClient.AddQueryString(request, "game", _game); }
            return await httpHelperClient.ExecuteRequest(request);
        }

        #endregion

        #region Teams - Https://dev.twitch.tv/docs/v5/reference/teams/

        /// <summary>
        /// Gets all of the active teams.
        /// Https://dev.twitch.tv/docs/v5/reference/teams/#get-all-teams
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public async Task<dynamic> GetTeams(Pagination _pagination) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/teams", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Gets a single team object.
        /// Https://dev.twitch.tv/docs/v5/reference/teams/#get-team
        /// </summary>
        /// <param name="_teamName">Team name</param>
        /// <returns></returns>
        public async Task<dynamic> GetTeam(string _teamName) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/teams/{_teamName}", HttpMethod.Get);
            return await httpHelperClient.ExecuteRequest(request);
        }

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        /// <summary>
        /// Gets a specified user object.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#get-user-by-id
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <returns></returns>
        public async Task<dynamic> GetUser(string _userId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users/{_userId}", HttpMethod.Get);
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Gets a list of all channels followed by a specified user, sorted by the date when they started following each channel.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#get-user-follows
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_direction">Sort direction <see cref="Enums.SortDirection"/></param>
        /// <param name="_sortKey">Sort key <see cref="Enums.SortKey"/></param>
        /// <returns></returns>
        public async Task<dynamic> GetUserFollowedChannels(string _userId, Pagination _pagination, SortDirection _direction = SortDirection.desc, SortKey _sortKey = SortKey.created_at) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users/{_userId}/follows/channels", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            httpHelperClient.AddQueryString(request, "direction", _direction.ToString());
            httpHelperClient.AddQueryString(request, "sortby", _sortKey.ToString());
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Checks if a specified user follows a specified channel. 
        /// Https://dev.twitch.tv/docs/v5/reference/users/#check-user-follows-by-channel
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_channelId">Channel Id to check</param>
        /// <returns></returns>
        public async Task<dynamic> CheckUserFollowsByChannel(string _userId, string _channelId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users/{_userId}/follows/channels/{_channelId}", HttpMethod.Get);
            return await httpHelperClient.ExecuteRequest(request, HttpStatusCode.OK | HttpStatusCode.NotFound);
        }

        /// <summary>
        /// ** Unofficial API **
        /// Checks if a specified user follows a specified game. 
        /// </summary>
        /// <param name="_username">Username</param>
        /// <param name="_game">Game to check</param>
        /// <returns></returns>
        public async Task<dynamic> CheckUserFollowsByGame(string _username, string _game) {
            var request = httpHelperClient.CreateHttpRequest($"api/users/{_username}/follows/games/{_game}", HttpMethod.Get);
            return await httpHelperClient.ExecuteRequest(request, HttpStatusCode.OK | HttpStatusCode.NotFound);
        }
        
        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        /// <summary>
        /// Gets a specified video object.
        /// Https://dev.twitch.tv/docs/v5/reference/videos/#get-video
        /// </summary>
        /// <param name="_videoId">Video Id</param>
        /// <returns></returns>
        public async Task<dynamic> GetVideo(string _videoId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/videos/{_videoId}", HttpMethod.Get);
            return await httpHelperClient.ExecuteRequest(request);
        }

        /// <summary>
        /// Gets the top videos based on viewcount.
        /// Https://dev.twitch.tv/docs/v5/reference/videos/#get-top-videos
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_game">Game name</param>
        /// <param name="_period">Period range <see cref="Enums.Period"/></param>
        /// <param name="_broadcastType">Broadcast type <see cref="Enums.BroadcastType"/></param>
        /// <returns></returns>
        public async Task<dynamic> GetTopVideos(Pagination _pagination, string _game = default(string), Period _period = Period.week, BroadcastType _broadcastType = BroadcastType.highlight) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/videos/top", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            if (!string.IsNullOrEmpty(_game)) { httpHelperClient.AddQueryString(request, "game", _game); }
            httpHelperClient.AddQueryString(request, "period", _period.ToString());
            httpHelperClient.AddQueryString(request, "broadcast_type", _broadcastType.ToString());
            return await httpHelperClient.ExecuteRequest(request);
        }

        #endregion
    }
}
