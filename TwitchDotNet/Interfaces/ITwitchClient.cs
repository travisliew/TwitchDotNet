using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchDotNet.Enums;
using TwitchDotNet.Helpers;

namespace TwitchDotNet.Interfaces {

    /// <summary>
    /// TwitchClient Interface for  requests to Twitch API
    /// </summary>
    public interface ITwitchClient {

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/
        
        Task<dynamic> GetChannel(string _channelId);
        Task<dynamic> GetChannelFollowers(string _channelId, Pagination _pagination, SortDirection _direction = SortDirection.desc);
        Task<dynamic> GetChannelTeams(string _channelId);
        Task<dynamic> GetChannelVideos(string _channelId, Pagination _pagination, BroadcastType _broadcastType = BroadcastType.highlight, List<string> _language = default(List<string>), SortBy _sort = SortBy.time);

        #endregion

        #region Chat - Https://dev.twitch.tv/docs/v5/reference/chat/

        Task<dynamic> GetChatBadgesByChannel(string _channelId);
        Task<dynamic> GetChatBadgesBySet(List<string> _emoteSets = default(List<string>));
        Task<dynamic> GetEmoticons();

        #endregion

        #region Games - Https://dev.twitch.tv/docs/v5/reference/games/

        Task<dynamic> GetTopGames(Pagination _pagination);
        Task<dynamic> GetFollowedGames(string _username, Pagination _pagination);

        #endregion

        #region Ingests - Https://dev.twitch.tv/docs/v5/reference/ingests/

        Task<dynamic> GetIngests();

        #endregion

        #region Search - Https://dev.twitch.tv/docs/v5/reference/search/

        Task<dynamic> SearchChannels(string _query, Pagination _pagination);
        Task<dynamic> SearchStreams(string _query, Pagination _pagination, bool _hls = true);
        Task<dynamic> SearchGames(string _query, bool _live = false);

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        Task<dynamic> GetStreams(Pagination _pagination, string _game = default(string), List<string> _channels = default(List<string>), StreamType _streamType = StreamType.live, List<string> _languages = default(List<string>));
        Task<dynamic> GetStream(string _channelId, StreamType _streamType = StreamType.live);
        Task<dynamic> GetFeaturedStreams(Pagination _pagination);
        Task<dynamic> GetStreamsSummary(string _game = default(string));

        #endregion

        #region Teams - Https://dev.twitch.tv/docs/v5/reference/teams/

        Task<dynamic> GetTeams(Pagination _pagination);
        Task<dynamic> GetTeam(string _teamName);

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/
        
        Task<dynamic> GetUser(string _userId);
        Task<dynamic> GetUserFollowedChannels(string _userId, Pagination _pagination, SortDirection _direction = SortDirection.desc, SortKey _sortBy = SortKey.created_at);
        Task<dynamic> CheckUserFollowsByChannel(string _userId, string _channelId);
        // Unofficial
        Task<dynamic> CheckUserFollowsByGame(string _username, string _game);

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        Task<dynamic> GetVideo(string _videoId);
        Task<dynamic> GetTopVideos(Pagination _pagination, string _game = default(string), Period _period = Period.week, BroadcastType _broadcastType = BroadcastType.highlight);

        #endregion
    }
}
