import './App.css';
import { createStyles, makeStyles, Theme } from '@material-ui/core/styles';
import AddIcon from '@material-ui/icons/Add';
import Container from '@material-ui/core/Container';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import IconButton from '@material-ui/core/IconButton';
import SweepstakeList from './components/SweepstakeList.js';

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        title: {
            flexGrow: 1,
        },
    }),
);

function App() {
    const classes = useStyles();

    return (
        <Container maxWidth="sm">
            <AppBar position="static">
                <Toolbar>
                    <Typography variant="h6" className={classes.title}>
                        Sweepstakes Explorer
                    </Typography>
                    <div>
                        <IconButton
                            aria-controls="menu-appbar"
                            aria-haspopup="true"
                            aria-label="menu"
                            color="inherit">
                            <AddIcon />
                        </IconButton>
                    </div>
                </Toolbar>
            </AppBar>
            <SweepstakeList>
            </SweepstakeList>
        </Container>
    );
}

export default App;
