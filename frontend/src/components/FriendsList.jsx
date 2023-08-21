import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function FriendsList({ currentUser }) {
  const [user, setUser] = useState(currentUser);
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

  const selectFriend = async (item) => {
    setChatTargetId(item.id);
    setChatTarget(item.username);
    const ids = {
      CurrentId: user.id,
      FriendId: chatTargetId,
    };
    try {
      const response = await axios.post("/api/Chat", ids);
      console.log(response.data);
    } catch (error) {
      console.error("Error fetching data:", error);
    }

    setActiveChat(true);
  };

  return (
    <>
      {friends == null ? (
        ""
      ) : activeChat == false ? (
        <div className="friendslist">
          {friends.map((item) => (
            <div
              key={item.id}
              onClick={() => {
                selectFriend(item);
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
                onClick={() => {
                  selectFriend(item);
                }}
              >
                <UserProfile username={item.username}></UserProfile>
              </div>
            ))}
          </div>
          <div className="chat">
            <div className="chat-bar">
              <div className="chat-bar-primary">{chatTarget}</div>
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
            <div className="chat-box">chat</div>
            <form>
              <div className="chat-bar">
                <input className="chat-bar-primary" type="text" />
                <button>send</button>
              </div>
            </form>
          </div>
        </>
      )}
    </>
  );
}
