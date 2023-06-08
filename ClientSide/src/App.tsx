import axios from "axios";
import { useEffect, useState } from "react";

type Details = {
  name: string;
  latitude: string
  longitude: string
}

function App() {

  const [allPoints, setAllPoints] = useState<Details[]>();

  useEffect(() => {
    const fetchData = async () => {
      try {

        const { data } = await axios.get("http://localhost:5038/api");
        console.log(data);

        setAllPoints(data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchData();
  }, []);

  return (
    <>
    </>
  )
}

export default App
