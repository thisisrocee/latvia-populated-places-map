import { Details } from "../types/details";

export const filterPointsByName = (points: Details[], name: string): Details[] => {
    return points.filter((point) => point.name.toLowerCase().includes(name.toLowerCase()));
}
