
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

        [TestMethod] public void Test_GetChannelFeedPosts(string _channelId, Pagination _pagination = null, long _comments = 5) { }
        [TestMethod] public void Test_GetChannelFeedPost(string _channelId, string _postId, long _comments = 5) { }
        [TestMethod] public void Test_CreateChannelFeedPost(string _channelId, string _content, bool _share = false) { }
        [TestMethod] public void Test_DeleteChannelFeedPost(string _channelId, string _postId) { }
        [TestMethod] public void Test_CreateReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId) { }
        [TestMethod] public void Test_DeleteReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId) { }
        [TestMethod] public void Test_GetChannelFeedPostComments(string _channelId, string _postId, Pagination _pagination = null) { }
        [TestMethod] public void Test_CreateChannelFeedPostComment(string _channelId, string _postId, string _content) { }
        [TestMethod] public void Test_DeleteChannelFeedPostComment(string _channelId, string _postId, string _commentId) { }
        [TestMethod] public void Test_CreateReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId) { }
        [TestMethod] public void Test_DeleteReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId) { }

        #endregion

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        [TestMethod] public void Test_GetChannel() { }
        [TestMethod] public void Test_UpdateChannel(string _channelId, string _status, string _game, string _delay, bool _channelFeedEnabled) { }
        [TestMethod] public void Test_GetChannelEditors(string _channelId) { }
        [TestMethod] public void Test_GetChannelSubscribers(string _channelId, Pagination _pagination = null, SortDirection _direction = SortDirection.asc) { }
        [TestMethod] public void Test_CheckChannelSubscriptionByUser(string _channelId, string _targetUserId) { }
        [TestMethod] public void Test_StartChannelCommercial(string _channelId) { }
        [TestMethod] public void Test_ResetChannelStreamKey(string _channelId) { }

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        [TestMethod] public void Test_GetFollowedStreams(Pagination _pagination = null, StreamType _streamType = StreamType.live) { }

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        [TestMethod] public void Test_GetUser() { }
        [TestMethod] public void Test_GetUserEmotes(string _userId) { }
        [TestMethod] public void Test_CheckUserSubscriptionByChannel(string _userId, string _channelId) { }
        [TestMethod] public void Test_FollowChannel(string _userId, string _targetChannelId, bool _enableNotifications = false) { }
        [TestMethod] public void Test_UnfollowChannel(string _userId, string _targetChannelId) { }
        [TestMethod] public void Test_GetUserBlockList(string _userId, Pagination _pagination = null) { }
        [TestMethod] public void Test_BlockUser(string _userId, string _targetUserId) { }
        [TestMethod] public void Test_UnblockUser(string _userId, string _targetUserId) { }

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        [TestMethod] public void Test_GetFollowedVideos(Pagination _pagination = null, BroadcastType _broadcastType = BroadcastType.highlight) { }

        #endregion
    }
}