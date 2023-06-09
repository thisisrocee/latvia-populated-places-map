import { MapContainer, Marker, Popup, TileLayer, useMapEvents } from "react-leaflet";
import { Details } from "../types/details";

type MapProps = {
  points: Details[];
  filteredPoints: Details[];
};

const Map: React.FC<MapProps> = ({ points, filteredPoints }) => {
  const generatePoint = (array: Details[]): React.ReactNode => {
    return array.map((point): React.ReactNode => {
      return (
        <Marker
          key={point.name}
          position={[parseFloat(point.latitude), parseFloat(point.longitude)]}
        >
          <Popup>{point.name}</Popup>
        </Marker>
      );
    });
  };

  return (
    <MapContainer
      center={[56.946285, 24.105078]}
      zoom={8}
      scrollWheelZoom={true}
      className="relative z-0 h-screen"
    >
      <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
      {filteredPoints.length
        ? generatePoint(filteredPoints)
        : generatePoint(points)}
    </MapContainer>
  );
};

export default Map;
