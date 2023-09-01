import { useEffect, useState } from "react";
import NavBar from "./NavBar";
import FriendsList from "./FriendsList";
import UserList from "./UserList";
import PostsList from "./PostsList";
import MenuButton from "./MenuButton";

export default function MainPage() {
  const [currentUser, setCurrentUser] = useState(null);
  const [mainContent, setMainContent] = useState("UserList");

  useEffect(() => {
    const getUser = async () => {
      try {
        const response = await axios.get("/api/User");
        setCurrentUser(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    getUser();
  }, []);

  const changeContent = (state) => {
    setMainContent(state);
  };

  return (
    <div className="main-page">
      <NavBar currentUser={currentUser}></NavBar>
      <div className="main-container">
        <div className="side-box">
          <MenuButton todo={changeContent} content={"Posts"}></MenuButton>
          <MenuButton todo={changeContent} content={"UserList"}></MenuButton>
        </div>
        <div className="main-box">
          {mainContent == "Posts" ? (
            <PostsList currentUser={currentUser}></PostsList>
          ) : (
            <UserList currentUser={currentUser}></UserList>
          )}
        </div>
        <div className="side-box">
          <FriendsList currentUser={currentUser}></FriendsList>
        </div>
      </div>
    </div>
  );
}
