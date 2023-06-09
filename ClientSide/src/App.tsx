import { useEffect, useState } from "react";
import { Details } from "./types/details";
import { fetchAllPoints } from "./api/api";
import { filterPointsByName } from "./utils/filterPointsByName";
import { sortPointsByValue } from "./utils/sortPointsByValue";
import Map from "./components/Map";
import SearchButton from "./components/SearchButton";
import AutocompleteBox from "./components/AutoCompleteBox";
import parse from "autosuggest-highlight/parse";
import match from "autosuggest-highlight/match";

function App() {
  const [allPoints, setAllPoints] = useState<Details[]>([]);
  const [value, setValue] = useState<string | null>(null);
  const [showAutocomplete, setShowAutocomplete] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      const data = await fetchAllPoints();
      setAllPoints(data);
    };

    fetchData();
  }, []);

  const sortedByLatitude = sortPointsByValue(allPoints, "latitude").slice(0,1);
  const sortedRevByLatitde = sortPointsByValue(allPoints, "latitude").reverse().slice(1,2);
  const sortedByLongitude = sortPointsByValue(allPoints, "longitude").slice(0,1);
  const sortedRevByLongitude = sortPointsByValue(allPoints, "longitude").reverse().slice(1,2);

  const result = [
    ...sortedByLatitude,
    ...sortedRevByLatitde,
    ...sortedByLongitude,
    ...sortedRevByLongitude,
  ]

  const sortedByName = sortPointsByValue(allPoints, "name");
  const filteredPoints = value ? filterPointsByName(allPoints, value) : [];

  const handleAutocompleteChange = (newValue: string | null) => {
    setValue(newValue);
  };

  const handleSearchClick = () => {
    setShowAutocomplete((prev) => !prev);
  };

  return (
    <div>
      <Map points={result} filteredPoints={filteredPoints} />

      <SearchButton showAutocomplete={showAutocomplete} onClick={handleSearchClick} />

      {showAutocomplete && (
        <AutocompleteBox
          options={sortedByName.map((option) => option.name)}
          value={value}
          onChange={handleAutocompleteChange}
          renderOption={(props, option, { inputValue }) => {
            const matches = match(option, inputValue, { insideWords: true });
            const parts = parse(option, matches);

            return (
              <li {...props}>
                <div>
                  {parts.map((part, index) => (
                    <span
                      key={index}
                      style={{
                        fontWeight: part.highlight ? 700 : 400,
                      }}
                    >
                      {part.text}
                    </span>
                  ))}
                </div>
              </li>
            );
          }}
        />
      )}
    </div>
  );
}

export default App;
