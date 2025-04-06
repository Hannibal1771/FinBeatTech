import {useState} from 'react';

export const useDefaultFetching = (callback) => {
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState('');

    const fetching = async (page) => {
        try{
            setIsLoading(true);
            await callback(page);
        } catch (e) {
            setError(e.message);
        } finally {
            setIsLoading(false);
        }
    }

    return [fetching, isLoading, error]
}