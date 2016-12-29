
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

        [TestMethod]
        public void Test_GetIdByName() {
            string name = "trick2g";
            Assert.IsNotNull(twitchClientAuthenticated.GetIdByName(name));
        }

        #region ChannelFeed - Https://dev.twitch.tv/docs/v5/reference/channel-feed/

        [TestMethod]
        public void Test_GetChannelFeedPosts() {
            string channelId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.GetChannelFeedPosts(channelId, new CursorPagination()));
        }

        [TestMethod]
        public void Test_GetChannelFeedPost() {
            string channelId = "32220409"; // travy92
            string postId = "322204091482884560";
            Assert.IsNotNull(twitchClientAuthenticated.GetChannelFeedPost(channelId, postId));
        }

        // Test_CreateChannelFeedPost
        // Test_DeleteChannelFeedPost
        [TestMethod]
        public void Test_CreateAndDeleteChannelFeedPost() {
            string channelId = "32220409"; // travy92
            string content = "Test Post from TwitchDotNet Unit Test";

            // Create post
            var response = twitchClientAuthenticated.CreateChannelFeedPost(channelId, content);
            Assert.IsNotNull(response);

            // Delete post
            Assert.IsNotNull(twitchClientAuthenticated.DeleteChannelFeedPost(channelId, response.post.id.ToString()));
        }

        // Test_CreateReactionToChannelFeedPost
        // Test_DeleteReactionToChannelFeedPost
        [TestMethod]
        public void Test_CreateAndDeleteReactionToChannelFeedPost() {
            string channelId = "32220409"; // travy92
            string postId = "322204091482884560";
            string emoteId = "endorse";

            // Create reaction to post
            Assert.IsNotNull(twitchClientAuthenticated.CreateReactionToChannelFeedPost(channelId, postId, emoteId));

            // Delete reaction to post
            Assert.IsNotNull(twitchClientAuthenticated.DeleteReactionToChannelFeedPost(channelId, postId, emoteId));
        }

        [TestMethod]
        public void Test_GetChannelFeedPostComments() {
            string channelId = "32220409"; // travy92
            string postId = "322204091482884560";
            Assert.IsNotNull(twitchClientAuthenticated.GetChannelFeedPostComments(channelId, postId, new CursorPagination()));
        }

        // Test_CreateChannelFeedPostComment
        // Test_DeleteChannelFeedPostComment
        [TestMethod]
        public void Test_CreateAndDeleteChannelFeedPostComment() {
            string channelId = "32220409"; // travy92
            string postId = "322204091482884560";
            string content = "Test Comment from TwitchDotNet Unit Test";

            // Create post comment
            var response = twitchClientAuthenticated.CreateChannelFeedPostComment(channelId, postId, content);
            Assert.IsNotNull(response);

            // Delete post comment
            Assert.IsNotNull(twitchClientAuthenticated.DeleteChannelFeedPostComment(channelId, postId, response.id.ToString()));
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
            Assert.IsNotNull(twitchClientAuthenticated.CreateReactionToChannelFeedPostComment(channelId, postId, commentId, emoteId));

            // Delete reaction to post comment
            Assert.IsNotNull(twitchClientAuthenticated.DeleteReactionToChannelFeedPostComment(channelId, postId, commentId, emoteId));
        }

        #endregion

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        [TestMethod]
        public void Test_GetChannel() {
            Assert.IsNotNull(twitchClientAuthenticated.GetChannel());
        }

        [TestMethod]
        public void Test_UpdateChannel() {
            string channelId = "32220409"; // travy92
            string status = "test";
            string game = "League of Legends";
            string delay = "0";
            bool channelFeedEnabled = false;
            Assert.IsNotNull(twitchClientAuthenticated.UpdateChannel(channelId, status, game, delay, channelFeedEnabled));
        }

        [TestMethod]
        public void Test_GetChannelEditors() {
            string channelId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.GetChannelEditors(channelId));
        }

        [TestMethod]
        public void Test_GetChannelSubscribers() {
            // Expecting null as I don't have any subscribers
            string channelId = "28036688"; // travy92
            Assert.IsNull(twitchClientAuthenticated.GetChannelSubscribers(channelId, new Pagination()));
        }

        [TestMethod]
        public void Test_CheckChannelSubscriptionByUser() {
            string channelId = "32220409"; // travy92
            string targetUserId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientAuthenticated.CheckChannelSubscriptionByUser(channelId, targetUserId));
        }

        [TestMethod]
        public void Test_StartChannelCommercial() {
            string channelId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.ResetChannelStreamKey(channelId));
        }

        [TestMethod]
        public void Test_ResetChannelStreamKey() {
            string channelId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.ResetChannelStreamKey(channelId));
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
            Assert.IsNotNull(twitchClientAuthenticated.FollowGame(username, game));

            // Unfollow game
            Assert.IsNotNull(twitchClientAuthenticated.UnfollowGame(username, game));
        }

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        [TestMethod]
        public void Test_GetFollowedStreams() {
            Assert.IsNotNull(twitchClientAuthenticated.GetFollowedStreams(new Pagination()));
        }

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        [TestMethod]
        public void Test_GetUser() {
            Assert.IsNotNull(twitchClientAuthenticated.GetUser());
        }

        [TestMethod]
        public void Test_GetUserEmotes() {
            string userId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.GetUserEmotes(userId));
        }

        [TestMethod]
        public void Test_CheckUserSubscriptionByChannel() {
            string userId = "32220409"; // travy92
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientAuthenticated.CheckUserSubscriptionByChannel(userId, channelId));
        }

        // Test_FollowChannel
        // Test_UnfollowChannel
        [TestMethod]
        public void Test_FollowAndUnfollowChannel() {
            string userId = "32220409"; // travy92
            string targetChannelId = "44322889"; // dallas

            // Follow channel
            Assert.IsNotNull(twitchClientAuthenticated.FollowChannel(userId, targetChannelId));

            // Unfollow Channel
            Assert.IsNotNull(twitchClientAuthenticated.UnfollowChannel(userId, targetChannelId));
        }

        [TestMethod]
        public void Test_GetUserBlockList() {
            string userId = "32220409"; // travy92
            Assert.IsNotNull(twitchClientAuthenticated.GetUserBlockList(userId, new Pagination()));
        }

        // Test_BlockUser
        // Test_UnblockUser
        [TestMethod]
        public void Test_BlockAndUnblockUser() {
            string userId = "32220409"; // travy92
            string targetUserId = "28036688"; // trick2g

            // Block user
            Assert.IsNotNull(twitchClientAuthenticated.BlockUser(userId, targetUserId));

            // Unblock user
            Assert.IsNotNull(twitchClientAuthenticated.UnblockUser(userId, targetUserId));
        }

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        [TestMethod]
        public void Test_GetFollowedVideos() {
            Assert.IsNotNull(twitchClientAuthenticated.GetFollowedVideos(new Pagination()));
        }

        #endregion
    }
}