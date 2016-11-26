D=$(date +"%Y-%m-%d %H:%M:%S")
echo $D
curl -X PUT -d "{\"beacon_id\": \"2\", \"user_id\":1, \"hit_time\": \"$D\" }" -H "Content-type: application/json" -H 'Accept: application/json' http://localhost:5000/beacon_hit
