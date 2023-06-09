import { Details } from "../types/details";

export const sortPointsByValue = (
  objects: Details[],
  valueKey: keyof Details
): Details[] => {
  return [...objects].sort((a, b) => a[valueKey].localeCompare(b[valueKey]));
};
