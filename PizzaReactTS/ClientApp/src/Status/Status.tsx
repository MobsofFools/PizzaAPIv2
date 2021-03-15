import {useQuery} from 'react-query';
import CircularProgress from '@material-ui/core/CircularProgress';
import StatusBar from './StatusBar';

type Props = {
    orderId: string
}

const Status: React.FC<Props> = ({orderId}) => {
    const fetchStatus = async (): Promise<string> => 
    await (
        await fetch('https://localhost:44379/S/'+orderId)
    ).text();

    const {data, isLoading, error} = useQuery<string>(
        'status',
        fetchStatus
    );
    if(isLoading) return <CircularProgress/>
    if(error) return <div>Something went wrong...</div>
    return(
        
        <StatusBar status={data}/>
        
    );
}
export default Status;