using TwitchDotNet.Enums;
using TwitchDotNet.Helpers;
using TwitchDotNet.Interfaces;
using System.Net.Http;
using System;

namespace TwitchDotNet.Clients {

    /// <summary>
    /// Authenticated TwitchClient
    /// Provides an interface for an authenticated session to retrieve data from Twitch API's (where authentication is required)
    /// </summary>
    public class TwitchClientAuthenticated : TwitchClientUnauthenticated, ITwitchClientAuthenticated {

        /// <summary>
        /// Initialise HttpClient with headers for authenticated requests
        /// </summary>
        /// <param name="_baseUrl">Base Twitch API url</param>
        /// <param name="_clientId">Client Id header</param>
        /// <param name="_oauthToken">OAuth Token header</param>
        public TwitchClientAuthenticated(string _baseUrl, string _clientId, string _oauthToken) : base(_baseUrl, _clientId) {
            // Add authentication header to HttpHelper client
            httpHelperClient.AddHeader("Authorization", $"OAuth {_oauthToken}");
        }

        #region General

        public dynamic GetIdByName(string _name) {
            throw new NotImplementedException();
        }

        #endregion

        #region ChannelFeed - Https://dev.twitch.tv/docs/v5/reference/channel-feed/

        /// <summary>
        /// Gets posts from a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#get-multiple-feed-posts
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_comments">Number of comments to retrieve</param>
        /// <returns></returns>
        public dynamic GetChannelFeedPosts(string _channelId, Pagination _pagination = null, long _comments = 5) { return null; }

        /// <summary>
        /// Gets a specified post from a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#get-feed-post
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_comments">Number of comments to retrieve</param>
        /// <returns></returns>
        public dynamic GetChannelFeedPost(string _channelId, string _postId, long _comments = 5) { return null; }

        /// <summary>
        /// Creates a post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#create-feed-post
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_content">Content of the post</param>
        /// <param name="_share">If true, share a link to the post on the channel's Twitter feed (if connected)</param>
        /// <returns></returns>
        public dynamic CreateChannelFeedPost(string _channelId, string _content, bool _share = false) { return null; }

        /// <summary>
        /// Deletes a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#delete-feed-post
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id to delete</param>
        /// <returns></returns>
        public dynamic DeleteChannelFeedPost(string _channelId, string _postId) { return null; }

        /// <summary>
        /// reates a reaction to a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#create-reaction-to-a-feed-post
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_emoteId">Reaction emote to create</param>
        /// <returns></returns>
        public dynamic CreateReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId) { return null; }

        /// <summary>
        /// Deletes a specified reaction to a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#delete-reaction-to-a-feed-post
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_emoteId">Reaction emote to delete</param>
        /// <returns></returns>
        public dynamic DeleteReactionToChannelFeedPost(string _channelId, string _postId, string _emoteId) { return null; }

        /// <summary>
        /// Gets all comments on a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#get-feed-comments
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public dynamic GetChannelFeedPostComments(string _channelId, string _postId, Pagination _pagination = null) { return null; }

        /// <summary>
        /// Creates a comment to a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#create-feed-comment
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_content">Content of the comment</param>
        /// <returns></returns>
        public dynamic CreateChannelFeedPostComment(string _channelId, string _postId, string _content) { return null; }

        /// <summary>
        /// Deletes a specified comment on a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#delete-feed-comment
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_commentId">Comment Id to delete</param>
        /// <returns></returns>
        public dynamic DeleteChannelFeedPostComment(string _channelId, string _postId, string _commentId) { return null; }

        /// <summary>
        /// Creates a reaction to a specified comment on a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#create-reaction-to-a-feed-comment
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_commentId">Comment Id</param>
        /// <param name="_emoteId">Reaction emote to create</param>
        /// <returns></returns>
        public dynamic CreateReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId) { return null; }

        /// <summary>
        /// Deletes a reaction to a specified comment on a specified post in a specified channel feed.
        /// Https://dev.twitch.tv/docs/v5/reference/channel-feed/#delete-reaction-to-a-feed-comment
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_postId">Post Id</param>
        /// <param name="_commentId">Comment Id</param>
        /// <param name="_emoteId">Reaction emote to delete</param>
        /// <returns></returns>
        public dynamic DeleteReactionToChannelFeedPostComment(string _channelId, string _postId, string _commentId, string _emoteId) { return null; }

        #endregion

        #region Channels - Https://dev.twitch.tv/docs/v5/reference/channels/

        /// <summary>
        /// Gets a channel object based on the OAuth token provided.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel
        /// </summary>
        /// <returns></returns>
        public dynamic GetChannel() { return null; }

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
        public dynamic UpdateChannel(string _channelId, string _status, string _game, string _delay, bool _channelFeedEnabled) { return null; }

        /// <summary>
        /// Gets a list of users who are editors for a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-editors
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public dynamic GetChannelEditors(string _channelId) { return null; }

        /// <summary>
        /// Gets a list of users subscribed to a specified channel, sorted by the date when they subscribed.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-subscribers
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_direction">Sort direction <see cref="Enums.SortDirection"/></param>
        /// <returns></returns>
        public dynamic GetChannelSubscribers(string _channelId, Pagination _pagination = null, SortDirection _direction = SortDirection.asc) { return null; }

        /// <summary>
        /// Checks if a specified channel has a specified user subscribed to it.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#check-channel-subscription-by-user
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <param name="_targetUserId">Target User Id to check</param>
        /// <returns></returns>
        public dynamic CheckChannelSubscriptionByUser(string _channelId, string _targetUserId) { return null; }

        /// <summary>
        /// Starts a commercial (advertisement) on a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#start-channel-commercial
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public dynamic StartChannelCommercial(string _channelId) { return null; }

        /// <summary>
        /// Deletes the stream key for a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/channels/#reset-channel-stream-key
        /// </summary>
        /// <param name="_channelId">Channel Id</param>
        /// <returns></returns>
        public dynamic ResetChannelStreamKey(string _channelId) { return null; }

        #endregion

        #region Streams - Https://dev.twitch.tv/docs/v5/reference/streams/

        /// <summary>
        /// Gets the list of live streams a user follows based on the OAuth token provided.
        /// Https://dev.twitch.tv/docs/v5/reference/streams/#get-followed-streams
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_streamType">Stream type <see cref="Enums.StreamType"/></param>
        /// <returns></returns>
        public dynamic GetFollowedStreams(Pagination _pagination = null, StreamType _streamType = StreamType.live) { return null; }

        #endregion

        #region Users - Https://dev.twitch.tv/docs/v5/reference/users/

        /// <summary>
        /// Gets a user object based on the OAuth token provided.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#get-user
        /// </summary>
        /// <returns></returns>
        public dynamic GetUser() { return null; }

        /// <summary>
        /// Gets a list of the emojis and emoticons that the specified user can use in chat.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#get-user-emotes
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <returns></returns>
        public dynamic GetUserEmotes(string _userId) { return null; }

        /// <summary>
        /// Checks if a specified user is subscribed to a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#check-user-subscription-by-channel
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_channelId">Channel Id to check</param>
        /// <returns></returns>
        public dynamic CheckUserSubscriptionByChannel(string _userId, string _channelId) { return null; }

        /// <summary>
        /// Adds a specified user to the followers of a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#follow-channel
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_targetChannelId">Target Channel to follow</param>
        /// <param name="_enableNotifications">If true, the user gets email or push notifications (depending on his notification settings) when the channel goes live, false otherwise</param>
        /// <returns></returns>
        public dynamic FollowChannel(string _userId, string _targetChannelId, bool _enableNotifications = false) { return null; }

        /// <summary>
        /// Deletes a specified user from the followers of a specified channel.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#unfollow-channel
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_targetChannelId">Target Channel to unfollow</param>
        /// <returns></returns>
        public dynamic UnfollowChannel(string _userId, string _targetChannelId) { return null; }

        /// <summary>
        /// Gets a user’s block list.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#get-user-block-list
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <returns></returns>
        public dynamic GetUserBlockList(string _userId, Pagination _pagination = null) { return null; }

        /// <summary>
        /// Blocks the target user.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#block-user
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_targetUserId">Target User Id to block</param>
        /// <returns></returns>
        public dynamic BlockUser(string _userId, string _targetUserId) { return null; }

        /// <summary>
        /// Unblocks the target user.
        /// Https://dev.twitch.tv/docs/v5/reference/users/#unblock-user
        /// </summary>
        /// <param name="_userId">User Id</param>
        /// <param name="_targetUserId">Target User Id to unblock</param>
        /// <returns></returns>
        public dynamic UnblockUser(string _userId, string _targetUserId) { return null; }

        #endregion

        #region Videos - Https://dev.twitch.tv/docs/v5/reference/videos/

        /// <summary>
        /// Gets the videos from channels the user is following based on the OAuth token provided.
        /// Https://dev.twitch.tv/docs/v5/reference/videos/#get-followed-videos
        /// </summary>
        /// <param name="_pagination">Pagination info <see cref="Helpers.Pagination"/></param>
        /// <param name="_broadcastType">Broadcast type <see cref="Enums.BroadcastType"/></param>
        /// <returns></returns>
        public dynamic GetFollowedVideos(Pagination _pagination = null, BroadcastType _broadcastType = BroadcastType.highlight) { return null; }

        #endregion
    }
}
