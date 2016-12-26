using System.Collections.Generic;
using TwitchDotNet.Enums;
using TwitchDotNet.Helpers;
using TwitchDotNet.Interfaces;

namespace TwitchDotNet.Clients {

    /// <summary>
    /// Unauthenticated TwitchClient
    /// Provides an interface for an unauthenticated session to retrieve data from Twitch API's (where authentication is not required)
    /// </summary>
    public class TwitchClientUnauthenticated : ITwitchClientUnauthenticated {

        protected readonly HttpHelper httpHelperClient;
        private static string TWITCH_BASE_URL = "";

        /// <summary>
        /// Initialise HttpClient with headers for unauthenticated requests
        /// </summary>
        /// <param name="_clientId">Client Id header</param>
        public TwitchClientUnauthenticated(string _clientId) {
            httpHelperClient = new HttpHelper(TWITCH_BASE_URL, _clientId);
        }

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        /// <summary>
        /// Gets a specified channel object.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-by-id
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public dynamic GetChannel(string _channelId) { return null; }

        /// <summary>
        /// Gets a list of users who follow a specified channel, sorted by the date when they started following the channel (newest first, unless specified otherwise).
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-followers
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_direction">Sort direction <see cref="Enums.SortDirection"/></param>
        /// <returns></returns>
        public dynamic GetChannelFollowers(string _channelId, Pagination _pagination = null, SortDirection _direction = SortDirection.desc) { return null; }

        /// <summary>
        /// Gets a list of teams to which a specified channel belongs.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-teams
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public dynamic GetChannelTeams(string _channelId) { return null; }

        /// <summary>
        /// Gets a list of VODs (Video on Demand) from a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-videos
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_broadcastType">Broadcast type <see cref="Enums.BroadcastType"/></param>
        /// <param name="_language">Restrict VODs to specific language(s)</param>
        /// <param name="_sort">Sort by <see cref="Enums.SortBy"/></param>
        /// <returns></returns>
        public dynamic GetChannelVideos(string _channelId, Pagination _pagination = null, BroadcastType _broadcastType = BroadcastType.highlight, List<string> _language = default(List<string>), SortBy _sort = SortBy.time) { return null; }

        #endregion

        #region Chat - Https://dev.twitch.tv/docs/v5/reference/chat/

        /// <summary>
        /// Gets a list of badges that can be used in chat for a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/chat/#get-chat-badges-by-channel
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public dynamic GetChatBadgesByChannel(string _channelId) { return null; }

        /// <summary>
        /// Gets all chat emoticons (not including their images) in a specified set.
        /// Https://dev.twitch.tv/docs/v5/reference/chat/#get-chat-emoticons-by-set
        /// </summary>
        /// <param name="_emoteSets">Emote set</param>
        /// <returns></returns>
        public dynamic GetChatBadgesBySet(string _emoteSets = default(string)) { return null; }

        /// <summary>
        /// Gets all chat emoticons (including their images).
        /// Https://dev.twitch.tv/docs/v5/reference/chat/#get-all-chat-emoticons
        /// </summary>
        /// <returns></returns>
        public dynamic GetEmoticons() { return null; }

        #endregion

        #region Games - Https://dev.twitch.tv/docs/v5/reference/games/

        /// <summary>
        /// Get games by number of current viewers.
        /// Https://dev.twitch.tv/docs/v5/reference/games/#get-top-games
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public dynamic GetTopGames(Pagination _pagination = null) { return null; }

        #endregion

        #region Ingests - Https://dev.twitch.tv/docs/v5/reference/ingests/

        /// <summary>
        /// Gets a list of ingest servers.
        /// Https://dev.twitch.tv/docs/v5/reference/ingests/#get-ingest-server-list
        /// </summary>
        /// <returns></returns>
        public dynamic GetIngests() { return null; }

        #endregion

        #region Search - Https://dev.twitch.tv/docs/v5/reference/search/

        /// <summary>
        /// Search for channels based on the query parameter.
        /// Https://dev.twitch.tv/docs/v5/reference/search/#search-channels
        /// </summary>
        /// <param name="_query">Search query</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public dynamic SearchChannels(string _query, Pagination _pagination = null) { return null; }

        /// <summary>
        /// Search for streams based on the query parameter.
        /// Https://dev.twitch.tv/docs/v5/reference/search/#search-streams
        /// </summary>
        /// <param name="_query">Search query</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_hls">If true, return only HLS streams, false, only non-HLS streams</param>
        /// <returns></returns>
        public dynamic SearchStreams(string _query, Pagination _pagination = null, bool _hls = true) { return null; }

        /// <summary>
        /// Search for games based on the query parameter.
        /// Https://dev.twitch.tv/docs/v5/reference/search/#search-games
        /// </summary>
        /// <param name="_query">Search query</param>
        /// <param name="_type">Search type <see cref="Enums.SearchType"/></param>
        /// <param name="_live">If true, return only games that are live on at least one channel, false, return all</param>
        /// <returns></returns>
        public dynamic SearchGames(string _query, SearchType _type = SearchType.suggest, bool _live = false) { return null; }

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        /// <summary>
        /// Gets a list of all live streams.
        /// Https://dev.twitch.tv/docs/v5/reference/streams/#get-all-streams
        /// </summary>
        /// <returns></returns>
        public dynamic GetStreams() { return null; }

        /// <summary>
        /// Gets stream information (the stream object) for a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/streams/#get-stream-by-channel
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_streamType">Stream type <see cref="Enums.StreamType"/></param>
        /// <returns></returns>
        public dynamic GetStream(string _channelId, StreamType _streamType = StreamType.live) { return null; }

        /// <summary>
        /// Gets a list of all featured live streams.
        /// Https://dev.twitch.tv/docs/v5/reference/streams/#get-featured-streams
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public dynamic GetFeaturedStreams(Pagination _pagination = null) { return null; }

        /// <summary>
        /// Gets a summary of all live streams.
        /// Https://dev.twitch.tv/docs/v5/reference/streams/#get-streams-summary
        /// </summary>
        /// <param name="_game">Restrict summary to specific game</param>
        /// <returns></returns>
        public dynamic GetStreamsSummary(string _game = default(string)) { return null; }

        #endregion

        #region Teams - Https://dev.twitch.tv/docs/v5/reference/teams/

        /// <summary>
        /// Gets all of the active teams.
        /// Https://dev.twitch.tv/docs/v5/reference/teams/#get-all-teams
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public dynamic GetTeams(Pagination _pagination = null) { return null; }

        /// <summary>
        /// Gets a single team object.
        /// Https://dev.twitch.tv/docs/v5/reference/teams/#get-team
        /// </summary>
        /// <param name="_teamName">Team name</param>
        /// <returns></returns>
        public dynamic GetTeam(string _teamName) { return null; }

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        /// <summary>
        /// Gets a specified user object.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#get-user-by-id
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <returns></returns>
        public dynamic GetUser(string _userId) { return null; }

        /// <summary>
        /// Gets a list of all channels followed by a specified user, sorted by the date when they started following each channel.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#get-user-follows
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_direction">Sort direction <see cref="Enums.SortDirection"/></param>
        /// <param name="_sortKey">Sort key <see cref="Enums.SortKey"/></param>
        /// <returns></returns>
        public dynamic GetUserFollowedChannels(string _userId, Pagination _pagination = null, SortDirection _direction = SortDirection.desc, SortKey _sortKey = SortKey.created_at) { return null; }

        /// <summary>
        /// Checks if a specified user follows a specified channel. 
        /// Https://dev.twitch.tv/docs/v5/reference/users/#check-user-follows-by-channel
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_channelId">Channel Id to check</param>
        /// <returns></returns>
        public dynamic CheckUserFollowsByChannel(string _userId, string _channelId) { return null; }

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        /// <summary>
        /// Gets a specified video object.
        /// Https://dev.twitch.tv/docs/v5/reference/videos/#get-video
        /// </summary>
        /// <param name="_videoId">Video Id</param>
        /// <returns></returns>
        public dynamic GetVideo(string _videoId) { return null; }

        /// <summary>
        /// Gets the top videos based on viewcount.
        /// Https://dev.twitch.tv/docs/v5/reference/videos/#get-top-videos
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_game">Game name</param>
        /// <param name="_period">Period range <see cref="Enums.Period"/></param>
        /// <param name="_broadcastType">Broadcast type <see cref="Enums.BroadcastType"/></param>
        /// <returns></returns>
        public dynamic GetTopVideos(Pagination _pagination = null, string _game = default(string), Period _period = Period.week, BroadcastType _broadcastType = BroadcastType.highlight) { return null; }

        #endregion
    }
}
