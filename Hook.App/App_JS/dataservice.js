define('dataservice',
	[
		'dataservice.feed',
		'dataservice.user',
		'dataservice.favorite',
		'dataservice.follow',
		'dataservice.connection',
		'dataservice.group'
	],
	function (feed, user, favorite, follow, connection, group) {

		return {
			feed: feed,
			user: user,
			favorite: favorite,
			follow: follow,
			connection: connection,
			group: group
		}
	});