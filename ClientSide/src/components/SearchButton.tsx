import React from "react";
import SearchIcon from "@mui/icons-material/Search";

type SearchButtonProps = {
  showAutocomplete: boolean;
  onClick: () => void;
};

const SearchButton: React.FC<SearchButtonProps> = ({ showAutocomplete, onClick }) => {
  return (
    <div className="flex flex-row-reverse">
      <button
        className="z-1 mx-10 absolute text-center top-10 bg-white border border-gray-300 rounded-full
        shadow-sm px-3 py-3 text-sm focus:outline-none focus:ring-1
        focus:ring-blue-500 focus:border-blue-500"
        onClick={onClick}
      >
        <SearchIcon />
      </button>
    </div>
  );
};

export default SearchButton;
