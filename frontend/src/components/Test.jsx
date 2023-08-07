import { useEffect, useState } from "react";

export default function Test() {
  const [numbers, setNumbers] = useState(null);

  /*
  useEffect(() => {
    axios
      .get("/api/test")
      .then((res) => {
        setNumbers(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);
  */
  useEffect(() => {
    const getNums = async () => {
      try {
        const response = await axios.get("/api/test");
        setNumbers(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    getNums();
  }, []);

  return <div>{numbers}</div>;
}
