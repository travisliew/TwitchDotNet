
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

        [TestInitialize]
        public void Initialise()
        {
            // Retrieve config from Resources.resw
            string baseUrl = resourceLoader.GetString("TWITCH_API_BASE_URL");
            string clientId = resourceLoader.GetString("CLIENT_ID");

            // Init unauthenticated client
            twitchClientUnauthenticated = new TwitchClientUnauthenticated(baseUrl, clientId);
        }

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        [TestMethod] public void GetChannel(string _channelId) { }
        [TestMethod] public void GetChannelFollowers(string _channelId, Pagination _pagination = null, SortDirection _direction = SortDirection.desc) { }
        [TestMethod] public void GetChannelTeams(string _channelId) { }
        [TestMethod] public void GetChannelVideos(string _channelId, Pagination _pagination = null, BroadcastType _broadcastType = BroadcastType.highlight, List<string> _language = default(List<string>), SortBy _sort = SortBy.time) { }

        #endregion

        #region Chat - Https://dev.twitch.tv/docs/v5/reference/chat/

        [TestMethod] public void GetChatBadgesByChannel(string _channelId) { }
        [TestMethod] public void GetChatBadgesBySet(string _emoteSets = default(string)) { }
        [TestMethod] public void GetEmoticons() { }

        #endregion

        #region Games - Https://dev.twitch.tv/docs/v5/reference/games/

        [TestMethod] public void GetTopGames(Pagination _pagination = null) { }

        #endregion

        #region Ingests - Https://dev.twitch.tv/docs/v5/reference/ingests/

        [TestMethod] public void GetIngests() { }

        #endregion

        #region Search - Https://dev.twitch.tv/docs/v5/reference/search/

        [TestMethod] public void SearchChannels(string _query, Pagination _pagination = null) { }
        [TestMethod] public void SearchStreams(string _query, Pagination _pagination = null, bool _hls = true) { }
        [TestMethod] public void SearchGames(string _query, SearchType _type = SearchType.suggest, bool _live = false) { }

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        [TestMethod] public void GetStreams() { }
        [TestMethod] public void GetStream(string _channelId, StreamType _streamType = StreamType.live) { }
        [TestMethod] public void GetFeaturedStreams(Pagination _pagination = null) { }
        [TestMethod] public void GetStreamsSummary(string _game = default(string)) { }

        #endregion

        #region Teams - Https://dev.twitch.tv/docs/v5/reference/teams/

        [TestMethod] public void GetTeams(Pagination _pagination = null) { }
        [TestMethod] public void GetTeam(string _teamName) { }

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        [TestMethod] public void GetUser(string _userId) { }
        [TestMethod] public void GetUserFollowedChannels(string _userId, Pagination _pagination = null, SortDirection _direction = SortDirection.desc, SortKey _sortBy = SortKey.created_at) { }
        [TestMethod] public void CheckUserFollowsByChannel(string _userId, string _channelId) { }

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        [TestMethod] public void GetVideo(string _videoId) { }
        [TestMethod] public void GetTopVideos() {
            var topVideos = twitchClientUnauthenticated.GetTopVideos();
            Assert.IsNotNull(topVideos);
        }

        #endregion
    }
}
