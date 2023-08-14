import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function FriendsList() {
  const [friends, setFriends] = useState(null);

  useEffect(() => {
    const getFriends = async () => {
      try {
        const response = await axios.get("/api/FriendsList");
        setFriends(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    getFriends();
  }, []);

  return (
    <div className="friendslist">
      {friends == null
        ? ""
        : friends.map((item) => (
            <UserProfile username={item.username} key={item.id}></UserProfile>
          ))}
    </div>
  );
}
