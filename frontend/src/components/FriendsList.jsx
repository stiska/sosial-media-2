import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function FriendsList() {
  const [friends, setFriends] = useState(null);
  const [activeChat, setActiveChat] = useState(true);
  const [chatTarget, setChatTarget] = useState("");

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
            <div
              key={item.id}
              className="this "
              onClick={() => {
                setActiveChat(true);
                setChatTarget(item.id);
                console.log("has run");
              }}
            >
              <UserProfile username={item.username}></UserProfile>
            </div>
          ))}
        </div>
      ) : (
        <>
          <div className="friendslist-w-chat">
            {friends.map((item) => (
              <div
                key={item.id}
                className="this "
                onClick={() => {
                  setActiveChat(true);
                  setChatTarget(item.id);
                  console.log("has run");
                }}
              >
                <UserProfile username={item.username}></UserProfile>
              </div>
            ))}
          </div>
          <div className="chat">
            Chatt!!!!{" "}
            <button onClick={() => setActiveChat(!activeChat)}>X</button>
          </div>
        </>
      )}
    </>
  );
}
