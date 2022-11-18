pipeline
{
	agent {label 'jenkins-slave-1'}
	environment
	{
		DOCKERHUB_CREDENTIALS = credentials('dockerhub')
	}
	stages
	{
		// stage('gitclone')
		// {
		// 	steps
		// 	{
		// 		git url: 'https://github.com/Psp29/app-api-nginx.git'
		// 	}
		// }
		stage('Login')
		{
			steps
			{
				sh 'echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_CREDENTIALS_USR --password-stdin'
			}
		}
		stage('Build')
		{
			steps
			{
				sh 'docker compose up -d --build'
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
