import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";
import Chat from "./Chat";

export default function FriendsList({ hasUppdate, currentUser }) {
  const [friends, setFriends] = useState(null);
  const [activeChat, setActiveChat] = useState(false);
  const [chatTarget, setChatTarget] = useState("");
  const [currentChat, setCurrentChat] = useState(null);
  //const [chatTargetId, setChatTargetId] = useState("");

  useEffect(() => {
    const getFriends = async () => {
      if (currentUser != null) {
        try {
          const response = await axios.get(
            "/api/FriendsList/" + currentUser.id
          );
          setFriends(response.data);
        } catch (error) {
          console.error("Error fetching data:", error);
        }
      } else {
        return;
      }
    };
    getFriends();
  }, [currentUser, hasUppdate]);

  const closeChat = () => {
    setActiveChat(false);
    setChatTarget("");
  };

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
      setCurrentChat(response.data);
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
          <Chat
            closeChat={closeChat}
            chatTarget={chatTarget}
            chatObject={currentChat}
            currentUser={currentUser}
          ></Chat>
        </>
      )}
    </>
  );
}
