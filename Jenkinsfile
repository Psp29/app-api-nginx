pipeline
{
	agent {label 'jenkins-slave-1'}
	environment
	{
		DOCKERHUB_CREDENTIALS = credentials('dockerhub')
	}
	stages
	{
		stage('Login')
		{
			steps
			{
				sh 'echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_CREDENTIALS_USR --password-stdin'
			}
		}
		stage('Prune Docker Data')
		{
			steps
			{
				sh 'docker system prune -a --volumes -f'
			}
		}
		stage('Build')
		{
			steps
			{
				sh 'docker compose up -d --build'
				sh 'docker compose ps'
			}
		}
		stage('Push')
		{
			steps
			{
				sh 'docker compose push'
			}
		}
		// stage('Deploy')
		// {
		// 	steps
		// 	{
		// 		sh 'docker compose up'
		// 	}
		// }
	}
post
	{
		always
		{
			sh 'docker logout'
		}
	}
}
