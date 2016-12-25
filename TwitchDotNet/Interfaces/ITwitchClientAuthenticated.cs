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
    internal interface ITwitchClientAuthenticated {

        #region ChannelFeed - https://dev.twitch.tv/docs/v5/reference/channel-feed/

        dynamic GetChannelFeedPosts(string _channelId, Pagination _pagination = null, long _comments = 5);
        dynamic GetChannelFeedPost(string _channelId, string _postId, long _comments = 5);
        dynamic CreateChannelFeedPost(string _channelId, string _content, bool _share = false);
        dynamic DeleteChannelFeedPost(string _channelId, string _postId);
        dynamic CreateReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId);
        dynamic DeleteReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId);
        dynamic GetChannelFeedPostComments(string _channelId, string _postId, Pagination _pagination = null);
        dynamic CreateChannelFeedPostComment(string _channelId, string _postId, string _content);
        dynamic DeleteChannelFeedPostComment(string _channelId, string _postId, string _commentId);
        dynamic CreateReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId);
        dynamic DeleteReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId);

        #endregion

        #region Channels - https://dev.twitch.tv/docs/v5/reference/channels/

        dynamic GetChannel();
        dynamic UpdateChannel(string _channelId, string _status, string _game, string _delay, bool _channelFeedEnabled);
        dynamic GetChannelEditors(string _channelId);
        dynamic GetChannelSubscribers(string _channelId, Pagination _pagination = null, SortDirection _direction = SortDirection.asc);
        dynamic CheckChannelSubscriptionByUser(string _channelId, string _targetUserId);
        dynamic StartChannelCommercial(string _channelId);
        dynamic ResetChannelStreamKey(string _channelId);

        #endregion

        #region Streams - https://dev.twitch.tv/docs/v5/reference/streams/

        dynamic GetFollowedStreams(Pagination _pagination = null, StreamType _streamType = StreamType.live);

        #endregion

        #region Users - https://dev.twitch.tv/docs/v5/reference/users/

        dynamic GetUser();
        dynamic GetUserEmotes(string _userId);
        dynamic CheckUserSubscriptionByChannel(string _userId, string _channelId);
        dynamic FollowChannel(string _userId, string _targetChannelId, bool _enableNotifications = false);
        dynamic UnfollowChannel(string _userId, string _targetChannelId);
        dynamic GetUserBlockList(string _userId, Pagination _pagination = null);
        dynamic BlockUser(string _userId, string _targetUserId);
        dynamic UnblockUser(string _userId, string _targetUserId);

        #endregion

        #region Videos - https://dev.twitch.tv/docs/v5/reference/videos/

        dynamic GetFollowedVideos(Pagination _pagination = null, string _game = default(string), Period _period = Period.week, BroadcastType _broadcastType = BroadcastType.highlight);

        #endregion
    }
}
