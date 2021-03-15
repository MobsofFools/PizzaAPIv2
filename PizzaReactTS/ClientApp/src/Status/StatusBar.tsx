import { PendingBar, InProgressBar, CompletedBar, BarBorder, BarText } from './StatusBar.styles';

type Props = {
    status: string | undefined;
}
const names = ["Andrew","Francis","Daniel","Phillip",
               "Pranav", "Noris", "Athena", "Hugh",
               "Ryan","Yuni","Yasir","Edvin" ];
function ranName() {
    return names[Math.floor(Math.random()*names.length)];
} 

const StatusBar: React.FC<Props> = ({ status }) => {
    if (status === "Pending") {
        return (
            <BarBorder>
                <PendingBar>
                    {status}
                </PendingBar>
            </BarBorder>
        );
    }
    if (status === "In Progress") {
        var ran = ranName()
        return (
            <BarBorder>
                <InProgressBar>
                    {ran} is making your pizza
                </InProgressBar>
            </BarBorder>
        );
    }
    if (status === "Completed") {
        return (
            <BarBorder>
                <CompletedBar>
                    Ready for Pickup
                </CompletedBar>
            </BarBorder>
        );
    }
    return (
        <BarBorder>
            <BarText>
                Error
            </BarText>
        </BarBorder>
    );
}
export default StatusBar;