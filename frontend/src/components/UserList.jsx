import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function UserList({ hasUppdate, todo, currentUser }) {
  const [users, setUsers] = useState(null);

  useEffect(() => {
    const getUsers = async () => {
      if (currentUser != null) {
        try {
          const response = await axios.get("/api/Users/" + currentUser.id);
          setUsers(response.data);
        } catch (error) {
          console.error("Error fetching data:", error);
        }
      } else {
        return;
      }
    };
    getUsers();
  }, [currentUser]);

  const addFriend = async (id) => {
    const ids = {
      UserId: currentUser.id,
      FriendId: id,
    };
    try {
      const response = await axios.post("/api/AddFriend", ids);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
    hasUppdate();
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
              <button onClick={() => todo(item.id)}>switch user</button>
            </div>
          ))}
        </div>
      )}
    </>
  );
}
