import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function Chat({ closeChat, chatTarget }) {
  return (
    <div className="chat">
      <div className="chat-bar">
        <div className="chat-bar-primary">{chatTarget}</div>
        <button onClick={closeChat}>X</button>
      </div>
      <div className="chat-box">chat</div>
      <form>
        <div className="chat-bar">
          <input className="chat-bar-primary" type="text" />
          <button>send</button>
        </div>
      </form>
    </div>
  );
}
