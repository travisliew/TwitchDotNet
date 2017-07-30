
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitchDotNet.Helpers;
using System.Net.Http;
using System.Collections.Generic;
using TwitchDotNet.Enums;
using TwitchDotNet.Clients;
using Windows.ApplicationModel.Resources;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TwitchDotNet.Tests
{
    [TestClass]
    public class TwitchClientTests {

        private static ResourceLoader resourceLoader = new ResourceLoader();
        private static TwitchClient twitchClient;

        [ClassInitialize]
        public static void Initialise(TestContext context) {
            // Retrieve config from Resources.resw
            string baseUrl = resourceLoader.GetString("TWITCH_API_BASE_URL");
            string clientId = resourceLoader.GetString("CLIENT_ID");

            // Init  client
            twitchClient = new TwitchClient(baseUrl, clientId);
        }

        #region General - https://dev.twitch.tv/docs/v5/guides/using-the-twitch-api

        [TestMethod]
        public void Test_GetIdByName() {
            string name = "trick2g";
            Assert.IsNotNull(twitchClient.GetIdByName(name).Result);
        }

        #endregion

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        [TestMethod]
        public void Test_GetChannel() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClient.GetChannel(channelId).Result);
        }

        [TestMethod]
        public void Test_GetChannelFollowers() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClient.GetChannelFollowers(channelId, new Pagination()).Result);
        }

        [TestMethod]
        public void Test_GetChannelTeams() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClient.GetChannelTeams(channelId).Result);
        }

        [TestMethod]
        public void Test_GetChannelVideos() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClient.GetChannelVideos(channelId, new Pagination()).Result);
        }

        #endregion

        #region Chat - Https://dev.twitch.tv/docs/v5/reference/chat/

        [TestMethod]
        public void Test_GetChatBadgesByChannel() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClient.GetChatBadgesByChannel(channelId).Result);
        }

        [TestMethod]
        public void Test_GetChatEmoticonsBySet() {
            Assert.IsNotNull(twitchClient.GetChatEmoticonsBySet().Result);
        }

        [TestMethod]
        public void Test_GetEmoticons() {
            Assert.IsNotNull(twitchClient.GetEmoticons().Result);
        }

        #endregion

        #region Games - Https://dev.twitch.tv/docs/v5/reference/games/

        [TestMethod]
        public void Test_GetTopGames() {
            Assert.IsNotNull(twitchClient.GetTopGames(new Pagination()).Result);
        }

        [TestMethod]
        public void Test_GetFollowedGames() {
            string username = "trick2g";
            Assert.IsNotNull(twitchClient.GetFollowedGames(username, new Pagination()).Result);
        }

        #endregion

        #region Ingests - Https://dev.twitch.tv/docs/v5/reference/ingests/

        [TestMethod]
        public void Test_GetIngests() {
            Assert.IsNotNull(twitchClient.GetIngests().Result);
        }

        #endregion

        #region Search - Https://dev.twitch.tv/docs/v5/reference/search/

        [TestMethod]
        public void Test_SearchChannels() {
            string query = "star";
            Assert.IsNotNull(twitchClient.SearchChannels(query, new Pagination()).Result);
        }

        [TestMethod]
        public void Test_SearchStreams() {
            string query = "star";
            Assert.IsNotNull(twitchClient.SearchStreams(query, new Pagination()).Result);
        }

        [TestMethod]
        public void Test_SearchGames() {
            string query = "star";
            Assert.IsNotNull(twitchClient.SearchGames(query).Result);
        }

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        [TestMethod]
        public void Test_GetStreams() { 
            Assert.IsNotNull(twitchClient.GetStreams(new Pagination()).Result);
            Assert.IsNotNull(twitchClient.GetStreams(new Pagination(), "Dungeons & Dragons").Result);
        }

        [TestMethod]
        public void Test_GetStream() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClient.GetStream(channelId).Result);
        }

        [TestMethod]
        public void Test_GetFeaturedStreams() {
            Assert.IsNotNull(twitchClient.GetFeaturedStreams(new Pagination()).Result);
        }

        [TestMethod]
        public void Test_GetStreamsSummary() {
            Assert.IsNotNull(twitchClient.GetStreamsSummary().Result);
        }

        #endregion

        #region Teams - Https://dev.twitch.tv/docs/v5/reference/teams/

        [TestMethod]
        public void Test_GetTeams() {
            Assert.IsNotNull(twitchClient.GetTeams(new Pagination()).Result);
        }

        [TestMethod]
        public void Test_GetTeam() {
            string teamName = "staff";
            Assert.IsNotNull(twitchClient.GetTeam(teamName).Result);
        }

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        [TestMethod]
        public void Test_GetUser() {
            string userId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClient.GetUser(userId).Result);
        }

        [TestMethod]
        public void Test_GetUserFollowedChannels() {
            string userId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClient.GetUserFollowedChannels(userId, new Pagination()).Result);
        }


        [TestMethod]
        public void Test_CheckUserFollowsByChannel() {
            // Am following, expecting result
            string userId = "32220409"; // travy92
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClient.CheckUserFollowsByChannel(userId, channelId).Result);
            
            // Not following, still expecting result (but 404 http code with message of "X is not following Y")
            channelId = "129454141";
            Assert.IsNotNull(twitchClient.CheckUserFollowsByChannel(userId, channelId).Result);
        }

        [TestMethod]
        public void Test_CheckUserFollowsByGame() {
            // Am following, expecting result
            string username = "travy92";
            string game = "League of Legends";
            Assert.IsNotNull(twitchClient.CheckUserFollowsByGame(username, game).Result);

            // Not following, still expecting result (but 404 http code with message of "X is not following Y")
            game = "Poker";
            Assert.IsNotNull(twitchClient.CheckUserFollowsByGame(username, game).Result);
        }

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        [TestMethod]
        public void Test_GetVideo() {
            // https://www.twitch.tv/twitch/v/106400740
            string videoId = "106400740";
            Assert.IsNotNull(twitchClient.GetVideo(videoId).Result);
        }

        [TestMethod]
        public void Test_GetTopVideos() {
            Assert.IsNotNull(twitchClient.GetTopVideos(new Pagination()).Result);

            // With game
            string game = "Overwatch";
            Assert.IsNotNull(twitchClient.GetTopVideos(new Pagination(), game).Result);
        }

        #endregion
    }
}
