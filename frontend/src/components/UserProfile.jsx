import { useEffect, useState } from "react";
export default function UserProfile() {
  const [user, setUser] = useState(null);

  useEffect(() => {
    const getNums = async () => {
      try {
        const response = await axios.get("/api/test");
        setUser(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    getNums();
  }, []);

  return (
    <div className="profile-container">
      <img src="src\assets\Default_pfp.svg.png" className="profile-img" />
      <div>{user == null ? "" : user.firstName + " " + user.lastName}</div>
    </div>
  );
}
