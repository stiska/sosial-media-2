export default function UserProfile({ username }) {
  return (
    <div className="profile-container">
      <img src="src\assets\Default_pfp.svg.png" className="profile-img" />
      <div>{username == null ? "" : username}</div>
    </div>
  );
}
