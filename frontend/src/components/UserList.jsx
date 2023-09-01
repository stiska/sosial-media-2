import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function UserList({ currentUser }) {
  const [users, setUsers] = useState(null);

  useEffect(() => {
    const getUsers = async () => {
      try {
        const response = await axios.get("/api/Users");
        console.log(response.data);
        setUsers(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    getUsers();
  }, []);

  const addFriend = async (id) => {
    const ids = {
      UserId: currentUser.id,
      FriendId: id,
    };
    try {
      const response = await axios.post("/api/AddFriend", ids);
      console.log(response.data);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  };
  return (
    <>
      {users == null ? (
        ""
      ) : (
        <div className="insert-somthing">
          {users.map((item) => (
            <div className="chat-bar" key={item.id}>
              <UserProfile username={item.username}></UserProfile>
              <button onClick={() => addFriend(item.id)}>add friend</button>
            </div>
          ))}
        </div>
      )}
    </>
  );
}
