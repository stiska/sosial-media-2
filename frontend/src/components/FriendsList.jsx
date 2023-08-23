import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function FriendsList({ currentUser }) {
  const [friends, setFriends] = useState(null);
  const [activeChat, setActiveChat] = useState(false);
  const [chatTarget, setChatTarget] = useState("");
  //const [chatTargetId, setChatTargetId] = useState("");

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

  const selectFriend = (item) => {
    setChatTarget(item.username);
    setChatRequest(item);
    setActiveChat(true);
  };
  const setChatRequest = async (item) => {
    const ids = {
      CurrentId: currentUser.id,
      FriendId: item.id,
    };
    try {
      const response = await axios.post("/api/Chat", ids);
      console.log(response.data);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
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
