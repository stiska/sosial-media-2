import FriendsList from "./FriendsList";
import NavBar from "./NavBar";
import PostsList from "./PostsList";

export default function MainPage() {
  return (
    <div className="main-page">
      <NavBar></NavBar>
      <div className="main-container">
        <div className="side-box">meny ting</div>
        <div className="main-box">
          <PostsList></PostsList>
        </div>
        <FriendsList></FriendsList>
      </div>
    </div>
  );
}
