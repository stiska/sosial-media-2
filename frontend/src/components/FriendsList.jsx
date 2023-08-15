import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function FriendsList() {
  const [friends, setFriends] = useState(null);
  const [activeChat, setActiveChat] = useState(true);

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
    <>
      {friends == null ? (
        ""
      ) : activeChat == false ? (
        <div className="friendslist">
          {friends.map((item) => (
            <UserProfile username={item.username} key={item.id}></UserProfile>
          ))}
        </div>
      ) : (
        <>
          <div className="friendslist-w-chat">
            {friends.map((item) => (
              <UserProfile username={item.username} key={item.id}></UserProfile>
            ))}
          </div>
          <div className="chat">Chatt!!!!</div>
        </>
      )}
    </>
  );
}
