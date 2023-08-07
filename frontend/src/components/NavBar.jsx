import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function NavBar() {
  const [user, setUser] = useState(null);

  useEffect(() => {
    const getUser = async () => {
      try {
        const response = await axios.get("/api/test");
        setUser(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    getUser();
  }, []);

  return (
    <div className="nav-bar">
      <div className="nav-bar-user">
        <UserProfile user={user}></UserProfile>
      </div>
      <input className="search-bar" type="text" />
      <button className="home-button">Home</button>
    </div>
  );
}
