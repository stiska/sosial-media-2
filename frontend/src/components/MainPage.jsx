import { useEffect, useState } from "react";
import NavBar from "./NavBar";
import FriendsList from "./FriendsList";
import UserList from "./UserList";
import PostsList from "./PostsList";
import MenuButton from "./MenuButton";

export default function MainPage() {
  const [currentUserId, setCurrentUserId] = useState(
    "290ee2b9-3277-46cf-9320-7674b06b670d"
  );
  const [currentUser, setCurrentUser] = useState(null);
  const [mainContent, setMainContent] = useState("Posts");
  const [hasUppdate, setHasUppdate] = useState(false);

  useEffect(() => {
    const getUser = async () => {
      try {
        const response = await axios.get("/api/User/" + currentUserId);
        setCurrentUser(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    getUser();
  }, [currentUserId]);

  const changeContent = (state) => {
    setMainContent(state);
  };

  const changeUser = (userId) => {
    setCurrentUserId(userId);
  };

  const reRender = () => {
    setHasUppdate(!hasUppdate);
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
            <UserList
              hasUppdate={reRender}
              todo={changeUser}
              currentUser={currentUser}
            ></UserList>
          )}
        </div>
        <div className="side-box">
          <FriendsList
            hasUppdate={hasUppdate}
            currentUser={currentUser}
          ></FriendsList>
        </div>
      </div>
    </div>
  );
}
