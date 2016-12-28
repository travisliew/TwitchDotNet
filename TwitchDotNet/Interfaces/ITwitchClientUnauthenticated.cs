using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchDotNet.Enums;
using TwitchDotNet.Helpers;

namespace TwitchDotNet.Interfaces {

    /// <summary>
    /// TwitchClient Interface for Unauthenticated requests to Twitch API
    /// </summary>
    internal interface ITwitchClientUnauthenticated {

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/
        
        dynamic GetChannel(string _channelId);
        dynamic GetChannelFollowers(string _channelId, Pagination _pagination, SortDirection _direction = SortDirection.desc);
        dynamic GetChannelTeams(string _channelId);
        dynamic GetChannelVideos(string _channelId, Pagination _pagination, BroadcastType _broadcastType = BroadcastType.highlight, List<string> _language = default(List<string>), SortBy _sort = SortBy.time);

        #endregion

        #region Chat - Https://dev.twitch.tv/docs/v5/reference/chat/

        dynamic GetChatBadgesByChannel(string _channelId);
        dynamic GetChatBadgesBySet(List<string> _emoteSets = default(List<string>));
        dynamic GetEmoticons();

        #endregion

        #region Games - Https://dev.twitch.tv/docs/v5/reference/games/

        dynamic GetTopGames(Pagination _pagination);

        #endregion

        #region Ingests - Https://dev.twitch.tv/docs/v5/reference/ingests/

        dynamic GetIngests();

        #endregion

        #region Search - Https://dev.twitch.tv/docs/v5/reference/search/

        dynamic SearchChannels(string _query, Pagination _pagination);
        dynamic SearchStreams(string _query, Pagination _pagination, bool _hls = true);
        dynamic SearchGames(string _query, bool _live = false);

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        dynamic GetStreams(Pagination _pagination, string _game = default(string), List<string> _channels = default(List<string>), StreamType _streamType = StreamType.live, List<string> _languages = default(List<string>));
        dynamic GetStream(string _channelId, StreamType _streamType = StreamType.live);
        dynamic GetFeaturedStreams(Pagination _pagination);
        dynamic GetStreamsSummary(string _game = default(string));

        #endregion

        #region Teams - Https://dev.twitch.tv/docs/v5/reference/teams/

        dynamic GetTeams(Pagination _pagination);
        dynamic GetTeam(string _teamName);

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/
        
        dynamic GetUser(string _userId);
        dynamic GetUserFollowedChannels(string _userId, Pagination _pagination, SortDirection _direction = SortDirection.desc, SortKey _sortBy = SortKey.created_at);
        dynamic CheckUserFollowsByChannel(string _userId, string _channelId);

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        dynamic GetVideo(string _videoId);
        dynamic GetTopVideos(Pagination _pagination, string _game = default(string), Period _period = Period.week, BroadcastType _broadcastType = BroadcastType.highlight);

        #endregion
    }
}
