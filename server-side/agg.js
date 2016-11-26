db.beacon_hits.aggregate(
		[
			{
				$match: {hit_time: {$gt: "aa"}}
			},
			{
				$group:{
					_id:"$user_id", 
					hits: {$push: {beacon_id: "$beacon_id", hit_time: "$hit_time"}}
				}
			},
			{
				$sort:{
					hit_time: -1
				}
			}
		]
	)