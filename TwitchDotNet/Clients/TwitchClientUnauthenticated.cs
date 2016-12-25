using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchDotNet.Interfaces;
using TwitchDotNet.Enums;
using TwitchDotNet.Helpers;

namespace TwitchDotNet.Clients {

    /// <summary>
    /// Unauthenticated TwitchClient
    /// Provides an interface for an unauthenticated session to retrieve data from Twitch API's (where authentication is not required)
    /// </summary>
    internal class TwitchClientUnauthenticated : ITwitchClientUnauthenticated {
        public dynamic CheckUserFollowsByChannel(string _userId, string _channelId) {
            throw new NotImplementedException();
        }

        public dynamic GetChannelById(string _channelId) {
            throw new NotImplementedException();
        }

        public dynamic GetChannelFollowers(string _channelId, Pagination _pagination = null, SortDirection _direction = SortDirection.desc) {
            throw new NotImplementedException();
        }

        public dynamic GetChannelTeams(string _channelId) {
            throw new NotImplementedException();
        }

        public dynamic GetChannelVideos(string _channelId, Pagination _pagination = null, BroadcastType _broadcastType = BroadcastType.highlight, List<string> _language = null, SortBy _sort = SortBy.time) {
            throw new NotImplementedException();
        }

        public dynamic GetChatBadgesByChannel(string _channelId) {
            throw new NotImplementedException();
        }

        public dynamic GetChatBadgesBySet(string _emoteSets = null) {
            throw new NotImplementedException();
        }

        public dynamic GetEmoticons() {
            throw new NotImplementedException();
        }

        public dynamic GetFeaturedStreams(Pagination _pagination = null) {
            throw new NotImplementedException();
        }

        public dynamic GetIngests() {
            throw new NotImplementedException();
        }

        public dynamic GetStream(string _channelId, StreamType _streamType = StreamType.live) {
            throw new NotImplementedException();
        }

        public dynamic GetStreams() {
            throw new NotImplementedException();
        }

        public dynamic GetStreamsSummary(string _game = null) {
            throw new NotImplementedException();
        }

        public dynamic GetTeam(string _teamName) {
            throw new NotImplementedException();
        }

        public dynamic GetTeams(Pagination _pagination = null) {
            throw new NotImplementedException();
        }

        public dynamic GetTopGames(Pagination _pagination = null) {
            throw new NotImplementedException();
        }

        public dynamic GetTopVideos(Pagination _pagination = null, string _game = null, Period _period = Period.week, BroadcastType _broadcastType = BroadcastType.highlight) {
            throw new NotImplementedException();
        }

        public dynamic GetUser(string _userId) {
            throw new NotImplementedException();
        }

        public dynamic GetUserFollowedChannels(string _userId, Pagination _pagination = null, SortDirection _direction = SortDirection.desc, SortKey _sortBy = SortKey.created_at) {
            throw new NotImplementedException();
        }

        public dynamic GetVideo(string _videoId) {
            throw new NotImplementedException();
        }

        public dynamic SearchChannels(string _query, Pagination _pagination = null) {
            throw new NotImplementedException();
        }

        public dynamic SearchGames(string _query, string _type = "suggest", bool _live = false) {
            throw new NotImplementedException();
        }

        public dynamic SearchStreams(string _query, Pagination _pagination = null, bool _hls = true) {
            throw new NotImplementedException();
        }
    }
}
