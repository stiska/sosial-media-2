import FriendsList from "./FriendsList";
import NavBar from "./NavBar";

export default function MainPage() {
  return (
    <div className="main-page">
      <NavBar></NavBar>
      <div className="main-container">
        <div className="side-box">meny ting</div>
        <div className="main-box">inlegg</div>
        <FriendsList></FriendsList>
      </div>
    </div>
  );
}
