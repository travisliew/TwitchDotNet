
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitchDotNet.Helpers;
using System.Net.Http;
using System.Collections.Generic;
using TwitchDotNet.Enums;
using TwitchDotNet.Clients;
using Windows.ApplicationModel.Resources;

namespace TwitchDotNet.Tests
{
    [TestClass]
    public class TwitchClientUnauthenticatedTests {

        private ResourceLoader resourceLoader = new ResourceLoader();
        private TwitchClientUnauthenticated twitchClientUnauthenticated;

        [ClassInitialize]
        public void Initialise()
        {
            // Retrieve config from Resources.resw
            string baseUrl = resourceLoader.GetString("TWITCH_API_BASE_URL");
            string clientId = resourceLoader.GetString("CLIENT_ID");

            // Init unauthenticated client
            twitchClientUnauthenticated = new TwitchClientUnauthenticated(baseUrl, clientId);
        }

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        [TestMethod]
        public void Test_GetChannel() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientUnauthenticated.GetChannel(channelId));
        }

        [TestMethod]
        public void Test_GetChannelFollowers() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientUnauthenticated.GetChannelFollowers(channelId, new Pagination()));
        }

        [TestMethod]
        public void Test_GetChannelTeams() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientUnauthenticated.GetChannelTeams(channelId));
        }

        [TestMethod]
        public void Test_GetChannelVideos() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientUnauthenticated.GetChannelVideos(channelId, new Pagination()));
        }

        #endregion

        #region Chat - Https://dev.twitch.tv/docs/v5/reference/chat/

        [TestMethod]
        public void Test_GetChatBadgesByChannel() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientUnauthenticated.GetChatBadgesByChannel(channelId));
        }

        [TestMethod]
        public void Test_GetChatBadgesBySet() {
            Assert.IsNotNull(twitchClientUnauthenticated.GetChatBadgesBySet());
        }

        [TestMethod]
        public void Test_GetEmoticons() {
            Assert.IsNotNull(twitchClientUnauthenticated.GetEmoticons());
        }

        #endregion

        #region Games - Https://dev.twitch.tv/docs/v5/reference/games/

        [TestMethod]
        public void Test_GetTopGames() {
            Assert.IsNotNull(twitchClientUnauthenticated.GetTopGames(new Pagination()));
        }

        #endregion

        #region Ingests - Https://dev.twitch.tv/docs/v5/reference/ingests/

        [TestMethod]
        public void Test_GetIngests() {
            Assert.IsNotNull(twitchClientUnauthenticated.GetIngests());
        }

        #endregion

        #region Search - Https://dev.twitch.tv/docs/v5/reference/search/

        [TestMethod]
        public void Test_SearchChannels() {
            string query = "star";
            Assert.IsNotNull(twitchClientUnauthenticated.SearchChannels(query, new Pagination()));
        }

        [TestMethod]
        public void Test_SearchStreams() {
            string query = "star";
            Assert.IsNotNull(twitchClientUnauthenticated.SearchStreams(query, new Pagination()));
        }

        [TestMethod]
        public void Test_SearchGames() {
            string query = "star";
            Assert.IsNotNull(twitchClientUnauthenticated.SearchGames(query));
        }

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        [TestMethod]
        public void Test_GetStreams() { 
            Assert.IsNotNull(twitchClientUnauthenticated.GetStreams(new Pagination()));
        }

        [TestMethod]
        public void Test_GetStream() {
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientUnauthenticated.GetStream(channelId));
        }

        [TestMethod]
        public void Test_GetFeaturedStreams() {
            Assert.IsNotNull(twitchClientUnauthenticated.GetFeaturedStreams(new Pagination()));
        }

        [TestMethod]
        public void Test_GetStreamsSummary() {
            Assert.IsNotNull(twitchClientUnauthenticated.GetStreamsSummary());
        }

        #endregion

        #region Teams - Https://dev.twitch.tv/docs/v5/reference/teams/

        [TestMethod]
        public void Test_GetTeams() {
            Assert.IsNotNull(twitchClientUnauthenticated.GetTeams(new Pagination()));
        }

        [TestMethod]
        public void Test_GetTeam() {
            string teamName = "staff";
            Assert.IsNotNull(twitchClientUnauthenticated.GetTeam(teamName));
        }

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        [TestMethod]
        public void Test_GetUser() {
            string userId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientUnauthenticated.GetUser(userId));
        }

        [TestMethod]
        public void Test_GetUserFollowedChannels() {
            string userId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientUnauthenticated.GetUserFollowedChannels(userId, new Pagination()));
        }


        [TestMethod]
        public void Test_CheckUserFollowsByChannel() {
            // Am following, expecting result
            string userId = "32220409"; // travy92
            string channelId = "28036688"; // trick2g
            Assert.IsNotNull(twitchClientUnauthenticated.CheckUserFollowsByChannel(userId, channelId));
            
            // Not following, expecting no result
            channelId = "129454141";
            Assert.IsNull(twitchClientUnauthenticated.CheckUserFollowsByChannel(userId, channelId));
        }

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        [TestMethod]
        public void Test_GetVideo() {
            // https://www.twitch.tv/twitch/v/106400740
            string videoId = "106400740";
            Assert.IsNotNull(twitchClientUnauthenticated.GetVideo(videoId));
        }

        [TestMethod]
        public void Test_GetTopVideos() {
            Assert.IsNotNull(twitchClientUnauthenticated.GetTopVideos(new Pagination()));

            // With game
            string game = "Overwatch";
            Assert.IsNotNull(twitchClientUnauthenticated.GetTopVideos(new Pagination(), game));
        }

        #endregion
    }
}
