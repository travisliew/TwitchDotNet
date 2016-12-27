
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitchDotNet.Helpers;
using TwitchDotNet.Enums;
using Windows.ApplicationModel.Resources;
using TwitchDotNet.Clients;
using System.Net.Http;

namespace TwitchDotNet.Tests {
    [TestClass]
    public class TwitchClientAuthenticatedTests {

        private ResourceLoader resourceLoader = new ResourceLoader();
        private TwitchClientAuthenticated twitchClientAuthenticated;

        [TestInitialize]
        public void Initialise() {
            // Retrieve config from Resources.resw
            string baseUrl = resourceLoader.GetString("TWITCH_API_BASE_URL");
            string clientId = resourceLoader.GetString("CLIENT_ID");
            string redirectUri = resourceLoader.GetString("AUTH_REDIRECT_URI");
            string scopes = resourceLoader.GetString("AUTH_SCOPES");
            string oauthToken = resourceLoader.GetString("OAUTH_TOKEN");

            // Init unauthenticated client
            // Manual OAuth Token as WebAuthenticationBroker for UWP doesn't work in a UnitTest
            twitchClientAuthenticated = new TwitchClientAuthenticated(baseUrl, clientId, oauthToken);
        }

        #region ChannelFeed - Https://dev.twitch.tv/docs/v5/reference/channel-feed/

        [TestMethod] public void GetChannelFeedPosts(string _channelId, Pagination _pagination = null, long _comments = 5) { }
        [TestMethod] public void GetChannelFeedPost(string _channelId, string _postId, long _comments = 5) { }
        [TestMethod] public void CreateChannelFeedPost(string _channelId, string _content, bool _share = false) { }
        [TestMethod] public void DeleteChannelFeedPost(string _channelId, string _postId) { }
        [TestMethod] public void CreateReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId) { }
        [TestMethod] public void DeleteReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId) { }
        [TestMethod] public void GetChannelFeedPostComments(string _channelId, string _postId, Pagination _pagination = null) { }
        [TestMethod] public void CreateChannelFeedPostComment(string _channelId, string _postId, string _content) { }
        [TestMethod] public void DeleteChannelFeedPostComment(string _channelId, string _postId, string _commentId) { }
        [TestMethod] public void CreateReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId) { }
        [TestMethod] public void DeleteReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId) { }

        #endregion

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        [TestMethod] public void GetChannel() { }
        [TestMethod] public void UpdateChannel(string _channelId, string _status, string _game, string _delay, bool _channelFeedEnabled) { }
        [TestMethod] public void GetChannelEditors(string _channelId) { }
        [TestMethod] public void GetChannelSubscribers(string _channelId, Pagination _pagination = null, SortDirection _direction = SortDirection.asc) { }
        [TestMethod] public void CheckChannelSubscriptionByUser(string _channelId, string _targetUserId) { }
        [TestMethod] public void StartChannelCommercial(string _channelId) { }
        [TestMethod] public void ResetChannelStreamKey(string _channelId) { }

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        [TestMethod] public void GetFollowedStreams(Pagination _pagination = null, StreamType _streamType = StreamType.live) { }

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        [TestMethod] public void GetUser() { }
        [TestMethod] public void GetUserEmotes(string _userId) { }
        [TestMethod] public void CheckUserSubscriptionByChannel(string _userId, string _channelId) { }
        [TestMethod] public void FollowChannel(string _userId, string _targetChannelId, bool _enableNotifications = false) { }
        [TestMethod] public void UnfollowChannel(string _userId, string _targetChannelId) { }
        [TestMethod] public void GetUserBlockList(string _userId, Pagination _pagination = null) { }
        [TestMethod] public void BlockUser(string _userId, string _targetUserId) { }
        [TestMethod] public void UnblockUser(string _userId, string _targetUserId) { }

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        [TestMethod] public void GetFollowedVideos(Pagination _pagination = null, BroadcastType _broadcastType = BroadcastType.highlight) { }

        #endregion
    }
}