import { Autocomplete, TextField } from "@mui/material";
import axios from "axios";
import React, { useEffect, useState } from "react";
import { MapContainer, Marker, Popup, TileLayer } from "react-leaflet";

type Details = {
  name: string;
  latitude: string;
  longitude: string;
};

function sortObjectsByValue(
  objects: Details[],
  valueKey: keyof Details
): Details[] {
  return [...objects].sort((a, b) => a[valueKey].localeCompare(b[valueKey]));
}

function App() {
  const [allPoints, setAllPoints] = useState<Details[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const { data } = await axios.get("http://localhost:5038/api");
        setAllPoints(data);
        console.log(data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchData();
  }, []);

  const sortedByLatitude = sortObjectsByValue(allPoints, "latitude")
  .slice(0, 1);
  const sortedRevByLatitude = sortObjectsByValue(allPoints, "latitude")
  .reverse().slice(1, 2);
  const sortedByLongitude = sortObjectsByValue(allPoints, "longitude")
  .slice(0, 1);
  const sortedRevByLongitude = sortObjectsByValue(allPoints, "longitude")
  .reverse().
  slice(1, 2);
  const sortedByName = sortObjectsByValue(allPoints, "name");

  const result = [
    ...sortedByLatitude,
    ...sortedRevByLatitude,
    ...sortedByLongitude,
    ...sortedRevByLongitude,
  ];

  const generateMarkers = (): React.ReactNode => {
    return result.map((point): React.ReactNode => {
      return (
        <>
          <Marker
            key={point.name}
            position={[parseFloat(point.latitude), parseFloat(point.longitude)]}
          >
            <Popup>{point.name}</Popup>
          </Marker>
          ;
        </>
      );
    });
  };

  const top100Films: string[] = [];

  sortedByName.forEach((element) => {
    top100Films.push(element.name);
  });

  return (
    <div>
      <MapContainer
        center={[56.946285, 24.105078]}
        zoom={8}
        scrollWheelZoom={true}
        className="relative z-0 h-screen"
      >
        <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
        {generateMarkers()}
      </MapContainer>
      <Autocomplete
      disablePortal
      id="search-box"
      options={top100Films}
      className="z-1 w-1/4 absolute top-10 align-center
      left-20 bg-white border border-gray-300 rounded-md
      shadow-sm px-4 py-2 text-sm focus:outline-none focus:ring-1
      focus:ring-blue-500 focus:border-blue-500"
      renderInput={(params) => <TextField {...params} label="Place" />}
    />
    </div>
  );
}

export default App;
