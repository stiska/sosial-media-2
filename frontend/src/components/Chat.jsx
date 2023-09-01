import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function Chat({
  closeChat,
  chatTarget,
  chatObject,
  currentUser,
}) {
  const [chat, setChat] = useState(null);
  const [reply, setReply] = useState("");

  useEffect(() => {
    if (chatObject == null) {
      return;
    } else {
      const getMeasages = async () => {
        try {
          const response = await axios.get("/api/Mesages/" + chatObject.id);
          setChat(response.data);
        } catch (error) {
          console.error("Error fetching data:", error);
        }
      };
      getMeasages();
    }
  }, [chatObject]);

  const handleSubmit = async (event) => {
    event.preventDefault();
    const message = {
      Content: reply,
      UserId: currentUser.id,
      ChatId: chatObject.id,
    };
    try {
      const response = await axios.post("/api/AddMesage", message);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
    const newChat = await axios.get("/api/Mesages/" + chatObject.id);
    setChat(newChat.data);
    setReply("");
  };

  const messageStyle = (Id) => {
    let style = { justifyContent: "flex-start" };
    if (Id == currentUser.id) {
      style = { justifyContent: "flex-end" };
    }
    return style;
  };

  return (
    <div className="chat">
      <div className="chat-bar">
        <div className="chat-bar-primary">{chatTarget}</div>
        <button onClick={closeChat}>X</button>
      </div>
      <div className="chat-box">
        {chat == null
          ? ""
          : chat.map((item) => (
              <div
                key={item.id}
                style={messageStyle(item.userId)}
                className="message"
              >
                {item.content}
              </div>
            ))}
      </div>
      <form>
        <div className="chat-bar">
          <input
            className="chat-bar-primary"
            value={reply}
            onChange={(e) => setReply(e.target.value)}
            type="text"
          />

          <button onClick={handleSubmit}>send</button>
        </div>
      </form>
    </div>
  );
}
