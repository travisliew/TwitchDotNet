using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchDotNet.Enums;
using TwitchDotNet.Helpers;
using TwitchDotNet.Interfaces;

namespace TwitchDotNet.Clients {

    /// <summary>
    /// Authenticated TwitchClient
    /// Provides an interface for an authenticated session to retrieve data from Twitch API's (where authentication is required)
    /// </summary>
    class TwitchClientAuthenticated : TwitchClientUnauthenticated, ITwitchClientAuthenticated {
        public dynamic BlockUser(string _userId, string _targetUserId) {
            throw new NotImplementedException();
        }

        public dynamic CheckChannelSubscriptionByUser(string _channelId, string _targetUserId) {
            throw new NotImplementedException();
        }

        public dynamic CheckUserSubscriptionByChannel(string _userId, string _channelId) {
            throw new NotImplementedException();
        }

        public dynamic CreateChannelFeedPost(string _channelId, string _content, bool _share = false) {
            throw new NotImplementedException();
        }

        public dynamic CreateChannelFeedPostComment(string _channelId, string _postId, string _content) {
            throw new NotImplementedException();
        }

        public dynamic CreateReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId) {
            throw new NotImplementedException();
        }

        public dynamic CreateReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId) {
            throw new NotImplementedException();
        }

        public dynamic DeleteChannelFeedPost(string _channelId, string _postId) {
            throw new NotImplementedException();
        }

        public dynamic DeleteChannelFeedPostComment(string _channelId, string _postId, string _commentId) {
            throw new NotImplementedException();
        }

        public dynamic DeleteReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId) {
            throw new NotImplementedException();
        }

        public dynamic DeleteReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId) {
            throw new NotImplementedException();
        }

        public dynamic FollowChannel(string _userId, string _targetChannelId, bool _enableNotifications = false) {
            throw new NotImplementedException();
        }

        public dynamic GetChannel() {
            throw new NotImplementedException();
        }

        public dynamic GetChannelEditors(string _channelId) {
            throw new NotImplementedException();
        }

        public dynamic GetChannelFeedPost(string _channelId, string _postId, long _comments = 5) {
            throw new NotImplementedException();
        }

        public dynamic GetChannelFeedPostComments(string _channelId, string _postId, Pagination _pagination = null) {
            throw new NotImplementedException();
        }

        public dynamic GetChannelFeedPosts(string _channelId, Pagination _pagination = null, long _comments = 5) {
            throw new NotImplementedException();
        }

        public dynamic GetChannelSubscribers(string _channelId, Pagination _pagination = null, SortDirection _direction = SortDirection.asc) {
            throw new NotImplementedException();
        }

        public dynamic GetFollowedStreams(Pagination _pagination = null, StreamType _streamType = StreamType.live) {
            throw new NotImplementedException();
        }

        public dynamic GetFollowedVideos(Pagination _pagination = null, string _game = null, Period _period = Period.week, BroadcastType _broadcastType = BroadcastType.highlight) {
            throw new NotImplementedException();
        }

        public dynamic GetUser() {
            throw new NotImplementedException();
        }

        public dynamic GetUserBlockList(string _userId, Pagination _pagination = null) {
            throw new NotImplementedException();
        }

        public dynamic GetUserEmotes(string _userId) {
            throw new NotImplementedException();
        }

        public dynamic ResetChannelStreamKey(string _channelId) {
            throw new NotImplementedException();
        }

        public dynamic StartChannelCommercial(string _channelId) {
            throw new NotImplementedException();
        }

        public dynamic UnblockUser(string _userId, string _targetUserId) {
            throw new NotImplementedException();
        }

        public dynamic UnfollowChannel(string _userId, string _targetChannelId) {
            throw new NotImplementedException();
        }

        public dynamic UpdateChannel(string _channelId, string _status, string _game, string _delay, bool _channelFeedEnabled) {
            throw new NotImplementedException();
        }
    }
}
