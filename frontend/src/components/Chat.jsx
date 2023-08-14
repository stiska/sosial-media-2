import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function Chat() {
  const [activChat, setActivChat] = useState(true);
  return (
    <div className="chat">{activChat == false ? "" : <div>chat</div>}</div>
  );
}
