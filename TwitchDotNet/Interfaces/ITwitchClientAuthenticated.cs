using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchDotNet.Enums;
using TwitchDotNet.Helpers;

namespace TwitchDotNet.Interfaces {

    /// <summary>
    /// TwitchClient Interface for Authenticated requests to Twitch API
    /// </summary>
    public interface ITwitchClientAuthenticated {

        #region General - https://dev.twitch.tv/docs/v5/guides/using-the-twitch-api

        Task<dynamic> GetIdByName(string _name);
        Task<dynamic> GetRoot();

        #endregion

        #region ChannelFeed - Https://dev.twitch.tv/docs/v5/reference/channel-feed/

        Task<dynamic> GetChannelFeedPosts(string _channelId, CursorPagination _pagination, long _comments = 5);
        Task<dynamic> GetChannelFeedPost(string _channelId, string _postId, long _comments = 5);
        Task<dynamic> CreateChannelFeedPost(string _channelId, string _content, bool _share = false);
        Task<dynamic> DeleteChannelFeedPost(string _channelId, string _postId);
        Task<dynamic> CreateReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId);
        Task<dynamic> DeleteReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId);
        Task<dynamic> GetChannelFeedPostComments(string _channelId, string _postId, CursorPagination _pagination);
        Task<dynamic> CreateChannelFeedPostComment(string _channelId, string _postId, string _content);
        Task<dynamic> DeleteChannelFeedPostComment(string _channelId, string _postId, string _commentId);
        Task<dynamic> CreateReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId);
        Task<dynamic> DeleteReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId);

        #endregion

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        Task<dynamic> GetChannel();
        Task<dynamic> UpdateChannel(string _channelId, string _status, string _game, string _delay, bool _channelFeedEnabled);
        Task<dynamic> GetChannelEditors(string _channelId);
        Task<dynamic> GetChannelSubscribers(string _channelId, Pagination _pagination, SortDirection _direction = SortDirection.asc);
        Task<dynamic> CheckChannelSubscriptionByUser(string _channelId, string _targetUserId);
        Task<dynamic> StartChannelCommercial(string _channelId);
        Task<dynamic> ResetChannelStreamKey(string _channelId);

        #endregion

        #region Game - Unsupported https://discuss.dev.twitch.tv/t/game-following-requests/2186

        Task<dynamic> FollowGame(string _username, string _game);
        Task<dynamic> UnfollowGame(string _username, string _game);

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        Task<dynamic> GetFollowedStreams(Pagination _pagination, StreamType _streamType = StreamType.live);

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        Task<dynamic> GetUser();
        Task<dynamic> GetUserEmotes(string _userId);
        Task<dynamic> CheckUserSubscriptionByChannel(string _userId, string _channelId);
        Task<dynamic> FollowChannel(string _userId, string _targetChannelId, bool _enableNotifications = false);
        Task<dynamic> UnfollowChannel(string _userId, string _targetChannelId);
        Task<dynamic> GetUserBlockList(string _userId, Pagination _pagination);
        Task<dynamic> BlockUser(string _userId, string _targetUserId);
        Task<dynamic> UnblockUser(string _userId, string _targetUserId);

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        Task<dynamic> GetFollowedVideos(Pagination _pagination, BroadcastType _broadcastType = BroadcastType.highlight);

        #endregion
    }
}
