using TwitchDotNet.Enums;
using TwitchDotNet.Helpers;
using TwitchDotNet.Interfaces;
using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace TwitchDotNet.Clients {

    /// <summary>
    /// Authenticated TwitchClient
    /// Provides an interface for an authenticated session to retrieve data from Twitch API's (where authentication is required)
    /// </summary>
    public class TwitchClientAuthenticated : TwitchClient, ITwitchClientAuthenticated {

        /// <summary>
        /// Initialise HttpClient for authenticated requests
        /// </summary>
        /// <param name="_baseUrl">Base Twitch API url</param>
        /// <param name="_clientId">Client Id header</param>
        /// <param name="_oauthToken">OAuth Token header</param>
        public TwitchClientAuthenticated(string _baseUrl, string _clientId, string _oauthToken) : base(_baseUrl, _clientId) {
            // Add authentication header to HttpHelper client
            httpHelperClient.AddHttpClientHeader("Authorization", $"OAuth {_oauthToken}");
        }

        #region General

        public dynamic GetIdByName(string _name) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, "login", _name);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        #endregion

        #region ChannelFeed - Https://dev.twitch.tv/docs/v5/reference/channel-feed/

        /// <summary>
        /// Gets posts from a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#get-multiple-feed-posts
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_cursorPagination">Cursor Pagination info <see cref="Helpers.CursorPagination"/></param>
        /// <param name="_comments">Number of comments to retrieve</param>
        /// <returns></returns>
        public dynamic GetChannelFeedPosts(string _channelId, CursorPagination _pagination, long _comments = 5) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/feed/{_channelId}/posts", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            httpHelperClient.AddQueryString(request, "comments", _comments.ToString());
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Gets a specified post from a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#get-feed-post
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_comments">Number of comments to retrieve</param>
        /// <returns></returns>
        public dynamic GetChannelFeedPost(string _channelId, string _postId, long _comments = 5) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/feed/{_channelId}/posts/{_postId}", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, "comments", _comments.ToString());
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Creates a post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#create-feed-post
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_content">Content of the post</param>
        /// <param name="_share">If true, share a link to the post on the channel's Twitter feed (if connected)</param>
        /// <returns></returns>
        public dynamic CreateChannelFeedPost(string _channelId, string _content, bool _share = false) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/feed/{_channelId}/posts", HttpMethod.Post);
            httpHelperClient.AddQueryString(request, "content", _content);
            httpHelperClient.AddQueryString(request, "share", _share.ToString());
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Deletes a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#delete-feed-post
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id to delete</param>
        /// <returns></returns>
        public dynamic DeleteChannelFeedPost(string _channelId, string _postId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/feed/{_channelId}/posts/{_postId}", HttpMethod.Delete);
            return httpHelperClient.ExecuteRequest(request).Result; ; }

        /// <summary>
        /// reates a reaction to a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#create-reaction-to-a-feed-post
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_emoteId">Reaction emote to create</param>
        /// <returns></returns>
        public dynamic CreateReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/feed/{_channelId}/posts/{_postId}/reactions", HttpMethod.Post);
            httpHelperClient.AddQueryString(request, "emote_id", _emoteId);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Deletes a specified reaction to a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#delete-reaction-to-a-feed-post
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_emoteId">Reaction emote to delete</param>
        /// <returns></returns>
        public dynamic DeleteReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/feed/{_channelId}/posts/{_postId}/reactions", HttpMethod.Delete);
            httpHelperClient.AddQueryString(request, "emote_id", _emoteId);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Gets all comments on a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#get-feed-comments
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.CursorPagination"/></param>
        /// <returns></returns>
        public dynamic GetChannelFeedPostComments(string _channelId, string _postId, CursorPagination _pagination) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/feed/{_channelId}/posts/{_postId}/comments", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Creates a comment to a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#create-feed-comment
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_content">Content of the comment</param>
        /// <returns></returns>
        public dynamic CreateChannelFeedPostComment(string _channelId, string _postId, string _content) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/feed/{_channelId}/posts/{_postId}/comments", HttpMethod.Post);
            httpHelperClient.AddQueryString(request, "content", _content);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Deletes a specified comment on a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#delete-feed-comment
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_commentId">Comment Id to delete</param>
        /// <returns></returns>
        public dynamic DeleteChannelFeedPostComment(string _channelId, string _postId, string _commentId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/feed/{_channelId}/posts/{_postId}/comments/{_commentId}", HttpMethod.Delete);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Creates a reaction to a specified comment on a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#create-reaction-to-a-feed-comment
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_commentId">Comment Id</param>
        /// <param name="_emoteId">Reaction emote to create</param>
        /// <returns></returns>
        public dynamic CreateReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/feed/{_channelId}/posts/{_postId}/comments/{_commentId}/reactions", HttpMethod.Post);
            httpHelperClient.AddQueryString(request, "emote_id", _emoteId);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Deletes a reaction to a specified comment on a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#delete-reaction-to-a-feed-comment
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_commentId">Comment Id</param>
        /// <param name="_emoteId">Reaction emote to delete</param>
        /// <returns></returns>
        public dynamic DeleteReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/feed/{_channelId}/posts/{_postId}/comments/{_commentId}/reactions", HttpMethod.Delete);
            httpHelperClient.AddQueryString(request, "emote_id", _emoteId);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        #endregion

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        /// <summary>
        /// Gets a channel object based on the OAuth token provided.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel
        /// </summary>
        /// <returns></returns>
        public dynamic GetChannel() {
            var request = httpHelperClient.CreateHttpRequest($"kraken/channel", HttpMethod.Get);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Updates specified properties of a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#update-channel
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_status">Broadcast status</param>
        /// <param name="_game">Game name</param>
        /// <param name="_delay">Channel delay in seconds</param>
        /// <param name="_channelFeedEnabled">If true, the channel's feed is turned on, false otherwise</param>
        /// <returns></returns>
        public dynamic UpdateChannel(string _channelId, string _status, string _game, string _delay, bool _channelFeedEnabled) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/channels/{_channelId}", HttpMethod.Put);

            // Only add as property if it is explicitly set, otherwise we will be overriding when not intending to
            var properties = new JObject();
            properties["channel"] = new JObject();
            if (_status != null) { properties["channel"]["status"] = _status; }
            if (_game != null) { properties["channel"]["game"] = _game; }
            if (_delay != null) { properties["channel"]["delay"] = _delay; }
            if (_channelFeedEnabled) { properties["channel"]["channel_feed_enabled"] = _channelFeedEnabled.ToString(); }

            request.Content = new StringContent(properties.ToString(), Encoding.UTF8,"application/json");
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Gets a list of users who are editors for a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-editors
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public dynamic GetChannelEditors(string _channelId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/channels/{_channelId}/editors", HttpMethod.Get);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Gets a list of users subscribed to a specified channel, sorted by the date when they subscribed.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-subscribers
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_direction">Sort direction <see cref="Enums.SortDirection"/></param>
        /// <returns></returns>
        public dynamic GetChannelSubscribers(string _channelId, Pagination _pagination, SortDirection _direction = SortDirection.asc) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/channels/{_channelId}/subscriptions", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            httpHelperClient.AddQueryString(request, "direction", _direction.ToString());
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Checks if a specified channel has a specified user subscribed to it.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#check-channel-subscription-by-user
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_targetUserId">Target User Id to check</param>
        /// <returns></returns>
        public dynamic CheckChannelSubscriptionByUser(string _channelId, string _targetUserId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/channels/{_channelId}/subscriptions/{_targetUserId}", HttpMethod.Get);
            // 422 Unprocessable Entity (no subscription program), 404 Not Found when user is not a subscriber of the channel
            return httpHelperClient.ExecuteRequest(request, HttpStatusCode.OK | (HttpStatusCode)422 | HttpStatusCode.NotFound).Result;
        }

        /// <summary>
        /// Starts a commercial (advertisement) on a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#start-channel-commercial
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public dynamic StartChannelCommercial(string _channelId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/channel/{_channelId}/commercial", HttpMethod.Post);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Deletes the stream key for a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#reset-channel-stream-key
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public dynamic ResetChannelStreamKey(string _channelId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/channels/{_channelId}/stream_key", HttpMethod.Delete);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        #endregion

        #region Game - Unofficial https://discuss.dev.twitch.tv/t/game-following-requests/2186

        /// <summary>
        /// Adds a specified user to the followers of a specified game.
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="_game"></param>
        /// <returns></returns>
        public dynamic FollowGame(string _username, string _game) {
            var request = httpHelperClient.CreateHttpRequest($"api/users/{_username}/follows/games/{_game}", HttpMethod.Put);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Deletes a specified user from the followers of a specified game.
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="_game"></param>
        /// <returns></returns>
        public dynamic UnfollowGame(string _username, string _game) {
            var request = httpHelperClient.CreateHttpRequest($"api/users/{_username}/follows/games/{_game}", HttpMethod.Delete);
            return httpHelperClient.ExecuteRequest(request, HttpStatusCode.NoContent).Result;
        }

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        /// <summary>
        /// Gets the list of live streams a user follows based on the OAuth token provided.
        /// Https://dev.twitch.tv/docs/v5/reference/streams/#get-followed-streams
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_streamType">Stream type <see cref="Enums.StreamType"/></param>
        /// <returns></returns>
        public dynamic GetFollowedStreams(Pagination _pagination, StreamType _streamType = StreamType.live) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/streams/followed", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            httpHelperClient.AddQueryString(request, "stream_type", _streamType.ToString());
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        /// <summary>
        /// Gets a user object based on the OAuth token provided.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#get-user
        /// </summary>
        /// <returns></returns>
        public dynamic GetUser() {
            var request = httpHelperClient.CreateHttpRequest($"kraken/user", HttpMethod.Get);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Gets a list of the emojis and emoticons that the specified user can use in chat.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#get-user-emotes
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <returns></returns>
        public dynamic GetUserEmotes(string _userId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users/{_userId}/emotes", HttpMethod.Get);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Checks if a specified user is subscribed to a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#check-user-subscription-by-channel
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_channelId">Channel Id to check</param>
        /// <returns></returns>
        public dynamic CheckUserSubscriptionByChannel(string _userId, string _channelId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users/{_userId}/subscriptions/{_channelId}", HttpMethod.Get);
            // 422 Unprocessable Entity (no subscription program), 404 Not Found when user is not a subscriber of the channel
            return httpHelperClient.ExecuteRequest(request, HttpStatusCode.OK | (HttpStatusCode)422 | HttpStatusCode.NotFound).Result;
        }

        /// <summary>
        /// Adds a specified user to the followers of a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#follow-channel
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_targetChannelId">Target Channel to follow</param>
        /// <param name="_enableNotifications">If true, the user gets email or push notifications (depending on his notification settings) when the channel goes live, false otherwise</param>
        /// <returns></returns>
        public dynamic FollowChannel(string _userId, string _targetChannelId, bool _enableNotifications = false) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users/{_userId}/follows/channels/{_targetChannelId}", HttpMethod.Put);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Deletes a specified user from the followers of a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#unfollow-channel
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_targetChannelId">Target Channel to unfollow</param>
        /// <returns></returns>
        public dynamic UnfollowChannel(string _userId, string _targetChannelId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users/{_userId}/follows/channels/{_targetChannelId}", HttpMethod.Delete);
            return httpHelperClient.ExecuteRequest(request, HttpStatusCode.NoContent).Result;
        }

        /// <summary>
        /// Gets a user’s block list.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#get-user-block-list
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public dynamic GetUserBlockList(string _userId, Pagination _pagination) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users/{_userId}/blocks", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Blocks the target user.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#block-user
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_targetUserId">Target User Id to block</param>
        /// <returns></returns>
        public dynamic BlockUser(string _userId, string _targetUserId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users/{_userId}/blocks/{_targetUserId}", HttpMethod.Put);
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        /// <summary>
        /// Unblocks the target user.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#unblock-user
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_targetUserId">Target User Id to unblock</param>
        /// <returns></returns>
        public dynamic UnblockUser(string _userId, string _targetUserId) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/users/{_userId}/blocks/{_targetUserId}", HttpMethod.Delete);
            return httpHelperClient.ExecuteRequest(request, HttpStatusCode.NoContent).Result;
        }

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        /// <summary>
        /// Gets the videos from channels the user is following based on the OAuth token provided.
        /// Https://dev.twitch.tv/docs/v5/reference/videos/#get-followed-videos
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_broadcastType">Broadcast type <see cref="Enums.BroadcastType"/></param>
        /// <returns></returns>
        public dynamic GetFollowedVideos(Pagination _pagination, BroadcastType _broadcastType = BroadcastType.highlight) {
            var request = httpHelperClient.CreateHttpRequest($"kraken/videos/followed", HttpMethod.Get);
            httpHelperClient.AddQueryString(request, _pagination);
            httpHelperClient.AddQueryString(request, "broadcast_type", _broadcastType.ToString());
            return httpHelperClient.ExecuteRequest(request).Result;
        }

        #endregion
    }
}
