import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function FriendsList() {
  const [friends, setFriends] = useState(null);
  const [activeChat, setActiveChat] = useState(false);
  const [chatTarget, setChatTarget] = useState("");
  const [chatTargetId, setChatTargetId] = useState("");

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
                setChatTargetId(item.id);
                setChatTarget(item.username);
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
                  setChatTargetId(item.id);
                  setChatTarget(item.username);
                }}
              >
                <UserProfile username={item.username}></UserProfile>
              </div>
            ))}
          </div>
          <div className="chat">
            <div className="chat-bar">
              <div className="chat-bar-person">{chatTarget}</div>
              <button
                onClick={() => {
                  setActiveChat(false);
                  setChatTargetId("");
                  setChatTarget("");
                }}
              >
                X
              </button>
            </div>
          </div>
        </>
      )}
    </>
  );
}
