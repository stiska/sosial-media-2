import { useEffect, useState } from "react";
import NavBar from "./NavBar";
import FriendsList from "./FriendsList";
import PostsList from "./PostsList";

export default function MainPage() {
  const [currentUser, setCurrentUser] = useState(null);

  useEffect(() => {
    const getUser = async () => {
      try {
        const response = await axios.get("/api/test");
        setCurrentUser(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    getUser();
  }, []);

  return (
    <div className="main-page">
      <NavBar currentUser={currentUser}></NavBar>
      <div className="main-container">
        <div className="side-box">meny ting</div>
        <div className="main-box">
          <PostsList currentUser={currentUser}></PostsList>
        </div>
        <div className="side-box">
          <FriendsList></FriendsList>
        </div>
      </div>
    </div>
  );
}
