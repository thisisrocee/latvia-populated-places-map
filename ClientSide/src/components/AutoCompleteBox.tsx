import React from "react";
import { Autocomplete, TextField, createFilterOptions } from "@mui/material";

type AutocompleteBoxProps = {
  options: string[];
  value: string | null;
  onChange: (value: string | null) => void;
  renderOption: (
    props: any,
    option: string,
    { inputValue }: { inputValue: string }
  ) => JSX.Element;
};

const AutocompleteBox: React.FC<AutocompleteBoxProps> = ({
  options,
  value,
  onChange,
  renderOption,
}) => {
  const filterOptions = createFilterOptions({
    matchFrom: "start",
    stringify: (option: string) => option,
    limit: 5,
  });

  return (
    <Autocomplete
      disablePortal
      id="search-box"
      options={options}
      filterOptions={filterOptions}
      className="z-1 w-1/4 absolute top-10 align-center
      left-20 bg-white border border-gray-300 rounded-md
      shadow-sm px-4 py-2 text-sm focus:outline-none focus:ring-1
      focus:ring-blue-500 focus:border-blue-500"
      renderInput={(params) => <TextField {...params} label="Place" />}
      value={value}
      onChange={(event, newValue) => onChange(newValue)}
      freeSolo
      renderOption={renderOption}
    />
  );
};

export default AutocompleteBox;
