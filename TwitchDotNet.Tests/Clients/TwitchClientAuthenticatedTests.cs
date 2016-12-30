
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitchDotNet.Helpers;
using TwitchDotNet.Enums;
using Windows.ApplicationModel.Resources;
using TwitchDotNet.Clients;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TwitchDotNet.Tests {
    [TestClass]
    public class TwitchClientAuthenticatedTests {

        private static ResourceLoader resourceLoader = new ResourceLoader();
        private static TwitchClientAuthenticated twitchClientAuthenticated;

        // Initialise base variables
        [ClassInitialize]
        public static void Initialise(TestContext context) {
            // Retrieve config from Resources.resw
            string baseUrl = resourceLoader.GetString("TWITCH_API_BASE_URL");
            string clientId = resourceLoader.GetString("CLIENT_ID");
            string redirectUri = resourceLoader.GetString("AUTH_REDIRECT_URI");
            string scopes = resourceLoader.GetString("AUTH_SCOPES");
            string oauthToken = resourceLoader.GetString("OAUTH_TOKEN");

            // Init  client
            // Manual OAuth Token as WebAuthenticationBroker for UWP doesn't work in a UnitTest
            twitchClientAuthenticated = new TwitchClientAuthenticated(baseUrl, clientId, oauthToken);
        }

        #region General - https://dev.twitch.tv/docs/v5/guides/using-the-twitch-api

        [TestMethod]
        public void Test_GetIdByName() {
            string name = "trick2g";
            Assert.IsNotNull(twitchClientAuthenticated.GetIdByName(name).Result);
        }

        [TestMethod]
        public void Test_GetRoot() {
            Assert.IsNotNull(twitchClientAuthenticated.GetRoot().Result);
        }

        #endregion

        #region ChannelFeed - Https://dev.twitch.tv/docs/v5/reference/channel-feed/

        [TestMethod]
        public void Test_GetChannelFeedPosts() {
            string channelId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.GetChannelFeedPosts(channelId, new CursorPagination()).Result);
        }

        [TestMethod]
        public void Test_GetChannelFeedPost() {
            string channelId = "32220409"; // travy92
            string postId = "322204091482884560";
            Assert.IsNotNull(twitchClientAuthenticated.GetChannelFeedPost(channelId, postId).Result);
        }

        // Test_CreateChannelFeedPost
        // Test_DeleteChannelFeedPost
        [TestMethod]
        public void Test_CreateAndDeleteChannelFeedPost() {
            string channelId = "32220409"; // travy92
            string content = "Test Post from TwitchDotNet Unit Test";

            // Create post
            var response = twitchClientAuthenticated.CreateChannelFeedPost(channelId, content).Result;
            Assert.IsNotNull(response);

            // Delete post
            Assert.IsNotNull(twitchClientAuthenticated.DeleteChannelFeedPost(channelId, response.post.id.ToString()).Result);
        }

        // Test_CreateReactionToChannelFeedPost
        // Test_DeleteReactionToChannelFeedPost
        [TestMethod]
        public void Test_CreateAndDeleteReactionToChannelFeedPost() {
            string channelId = "32220409"; // travy92
            string postId = "322204091482884560";
            string emoteId = "endorse";

            // Create reaction to post
            Assert.IsNotNull(twitchClientAuthenticated.CreateReactionToChannelFeedPost(channelId, postId, emoteId).Result);

            // Delete reaction to post
            Assert.IsNotNull(twitchClientAuthenticated.DeleteReactionToChannelFeedPost(channelId, postId, emoteId).Result);
        }

        [TestMethod]
        public void Test_GetChannelFeedPostComments() {
            string channelId = "32220409"; // travy92
            string postId = "322204091482884560";
            Assert.IsNotNull(twitchClientAuthenticated.GetChannelFeedPostComments(channelId, postId, new CursorPagination()).Result);
        }

        // Test_CreateChannelFeedPostComment
        // Test_DeleteChannelFeedPostComment
        [TestMethod]
        public void Test_CreateAndDeleteChannelFeedPostComment() {
            string channelId = "32220409"; // travy92
            string postId = "322204091482884560";
            string content = "Test Comment from TwitchDotNet Unit Test";

            // Create post comment
            var response = twitchClientAuthenticated.CreateChannelFeedPostComment(channelId, postId, content).Result;
            Assert.IsNotNull(response);

            // Delete post comment
            Assert.IsNotNull(twitchClientAuthenticated.DeleteChannelFeedPostComment(channelId, postId, response.id.ToString()).Result);
        }

        // Test_CreateReactionToChannelFeedPostComment
        // Test_DeleteReactionToChannelFeedPostComment
        [TestMethod]
        public void Test_CreateAndDeleteReactionToChannelFeedPostComment() {
            string channelId = "32220409"; // travy92
            string postId = "322204091482884560";
            string commentId = "157121";
            string emoteId = "endorse";
            
            // Create reaction to post comment
            Assert.IsNotNull(twitchClientAuthenticated.CreateReactionToChannelFeedPostComment(channelId, postId, commentId, emoteId).Result);

            // Delete reaction to post comment
            Assert.IsNotNull(twitchClientAuthenticated.DeleteReactionToChannelFeedPostComment(channelId, postId, commentId, emoteId).Result);
        }

        #endregion

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        [TestMethod]
        public void Test_GetChannel() {
            Assert.IsNotNull(twitchClientAuthenticated.GetChannel().Result);
        }

        [TestMethod]
        public void Test_UpdateChannel() {
            string channelId = "32220409"; // travy92
            string status = "test";
            string game = "League of Legends";
            string delay = "0";
            bool channelFeedEnabled = false;
            Assert.IsNotNull(twitchClientAuthenticated.UpdateChannel(channelId, status, game, delay, channelFeedEnabled).Result);
        }

        [TestMethod]
        public void Test_GetChannelEditors() {
            string channelId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.GetChannelEditors(channelId).Result);
        }

        [TestMethod]
        public void Test_GetChannelSubscribers() {
            // Expecting null as I don't have any subscribers
            string channelId = "28036688"; // travy92
            Assert.IsNull(twitchClientAuthenticated.GetChannelSubscribers(channelId, new Pagination()).Result);
        }

        [TestMethod]
        public void Test_CheckChannelSubscriptionByUser() {
            string channelId = "32220409"; // travy92
            string targetUserId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientAuthenticated.CheckChannelSubscriptionByUser(channelId, targetUserId).Result);
        }

        [TestMethod]
        public void Test_StartChannelCommercial() {
            string channelId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.ResetChannelStreamKey(channelId).Result);
        }

        [TestMethod]
        public void Test_ResetChannelStreamKey() {
            string channelId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.ResetChannelStreamKey(channelId).Result);
        }

        #endregion

        #region Game - Unofficial https://discuss.dev.twitch.tv/t/game-following-requests/2186

        // Test_FollowGame
        // Test_UnfollowGame
        [TestMethod]
        public void Test_FollowAndUnfollowGame() {
            string username = "travy92";
            string game = "Poker";

            // Follow game
            Assert.IsNotNull(twitchClientAuthenticated.FollowGame(username, game).Result);

            // Unfollow game
            Assert.IsNotNull(twitchClientAuthenticated.UnfollowGame(username, game).Result);
        }

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        [TestMethod]
        public void Test_GetFollowedStreams() {
            Assert.IsNotNull(twitchClientAuthenticated.GetFollowedStreams(new Pagination()).Result);
        }

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        [TestMethod]
        public void Test_GetUser() {
            Assert.IsNotNull(twitchClientAuthenticated.GetUser().Result);
        }

        [TestMethod]
        public void Test_GetUserEmotes() {
            string userId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.GetUserEmotes(userId).Result);
        }

        [TestMethod]
        public void Test_CheckUserSubscriptionByChannel() {
            string userId = "32220409"; // travy92
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientAuthenticated.CheckUserSubscriptionByChannel(userId, channelId).Result);
        }

        // Test_FollowChannel
        // Test_UnfollowChannel
        [TestMethod]
        public void Test_FollowAndUnfollowChannel() {
            string userId = "32220409"; // travy92
            string targetChannelId = "44322889"; // dallas

            // Follow channel
            Assert.IsNotNull(twitchClientAuthenticated.FollowChannel(userId, targetChannelId).Result);

            // Unfollow Channel
            Assert.IsNotNull(twitchClientAuthenticated.UnfollowChannel(userId, targetChannelId).Result);
        }

        [TestMethod]
        public void Test_GetUserBlockList() {
            string userId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.GetUserBlockList(userId, new Pagination()).Result);
        }

        // Test_BlockUser
        // Test_UnblockUser
        [TestMethod]
        public void Test_BlockAndUnblockUser() {
            string userId = "32220409"; // travy92
            string targetUserId = "28036688"; // trick2g

            // Block user
            Assert.IsNotNull(twitchClientAuthenticated.BlockUser(userId, targetUserId).Result);

            // Unblock user
            Assert.IsNotNull(twitchClientAuthenticated.UnblockUser(userId, targetUserId).Result);
        }

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        [TestMethod]
        public void Test_GetFollowedVideos() {
            Assert.IsNotNull(twitchClientAuthenticated.GetFollowedVideos(new Pagination()).Result);
        }

        #endregion
    }
}