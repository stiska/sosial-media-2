export default function UserProfile({ user }) {
  return (
    <div className="profile-container">
      <img src="src\assets\Default_pfp.svg.png" className="profile-img" />
      <div>{user == null ? "" : user.firstName + " " + user.lastName}</div>
    </div>
  );
}
