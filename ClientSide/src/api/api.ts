import axios from "axios";

export const fetchAllPoints = async () => {
    try {
        const { data } = await axios.get(import.meta.env.VITE_API_URL);
        return data;
    } catch (error) {
        console.log(error);
        return [];
    }
}
