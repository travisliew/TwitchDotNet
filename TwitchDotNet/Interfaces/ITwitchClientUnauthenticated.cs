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

        #region Channels - https://dev.twitch.tv/docs/v5/reference/channels/
        
        dynamic GetChannel(string _channelId);
        dynamic GetChannelFollowers(string _channelId, Pagination _pagination = null, SortDirection _direction = SortDirection.desc);
        dynamic GetChannelTeams(string _channelId);
        dynamic GetChannelVideos(string _channelId, Pagination _pagination = null, BroadcastType _broadcastType = BroadcastType.highlight, List<string> _language = default(List<string>), SortBy _sort = SortBy.time);

        #endregion

        #region Chat - https://dev.twitch.tv/docs/v5/reference/chat/

        dynamic GetChatBadgesByChannel(string _channelId);
        dynamic GetChatBadgesBySet(string _emoteSets = default(string));
        dynamic GetEmoticons();

        #endregion

        #region Games - https://dev.twitch.tv/docs/v5/reference/games/

        dynamic GetTopGames(Pagination _pagination = null);

        #endregion

        #region Ingests - https://dev.twitch.tv/docs/v5/reference/ingests/

        dynamic GetIngests();

        #endregion

        #region Search - https://dev.twitch.tv/docs/v5/reference/search/

        dynamic SearchChannels(string _query, Pagination _pagination = null);
        dynamic SearchStreams(string _query, Pagination _pagination = null, bool _hls = true);
        dynamic SearchGames(string _query, string _type = "suggest", bool _live = false);

        #endregion

        #region Streams - https://dev.twitch.tv/docs/v5/reference/streams/

        dynamic GetStreams();
        dynamic GetStream(string _channelId, StreamType _streamType = StreamType.live);
        dynamic GetFeaturedStreams(Pagination _pagination = null);
        dynamic GetStreamsSummary(string _game = default(string));

        #endregion

        #region Teams - https://dev.twitch.tv/docs/v5/reference/teams/

        dynamic GetTeams(Pagination _pagination = null);
        dynamic GetTeam(string _teamName);

        #endregion

        #region Users - https://dev.twitch.tv/docs/v5/reference/users/
        
        dynamic GetUser(string _userId);
        dynamic GetUserFollowedChannels(string _userId, Pagination _pagination = null, SortDirection _direction = SortDirection.desc, SortKey _sortBy = SortKey.created_at);
        dynamic CheckUserFollowsByChannel(string _userId, string _channelId);

        #endregion

        #region Videos - https://dev.twitch.tv/docs/v5/reference/videos/

        dynamic GetVideo(string _videoId);
        dynamic GetTopVideos(Pagination _pagination = null, string _game = default(string), Period _period = Period.week, BroadcastType _broadcastType = BroadcastType.highlight);

        #endregion
    }
}
